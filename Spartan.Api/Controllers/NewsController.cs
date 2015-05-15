using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using Spartan.Model.Models;
using Spartan.Services.Base;
using Spartan.Services.Interface;
using Spartan.Services.Services;
using Spartan.Api.Dto;
using Spartan.Api.Dto.Mapper;
using WebApiContrib.Filters;
using WebApiContrib.Selectors;
using Spartan.Framework.Config;

namespace Spartan.Api.Controllers
{
    [EnableCors]
    public class NewsController : BaseApiController
    {
        private readonly INewService _service;
        //利用依赖注入框架在MVC创建controller的时候传入INewService对应的实例对象
        public NewsController(INewService service)
            : base(service)
        {
            this._service = service;
        }

        public HttpResponseMessage Get(string search = "", int pageIndex = 1, int pageSize = SysConfig.PAGE_MIN_SIZE)
        {
            var query = _service.GetAllNews().Where(_ => _.NewName.Contains(search));
            int count = query.Count();
            var news = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(_ => ModelMapper.ToDto(_));
            var pages = count % pageSize > 0 ? count / pageSize + 1 : count / pageSize;
            return Response(HttpStatusCode.OK, PageListResult(news, count, pages));
        }

        // GET api/news/5
        public HttpResponseMessage Get(int id)
        {
            var newModel = _service.GetNew(id);
            return newModel == null
                ? Response(HttpStatusCode.NotFound)
                : Response(HttpStatusCode.OK, ModelMapper.ToDto(newModel));
        }

        public HttpResponseMessage GetNewByName(string name)
        {
            var newModels = _service.GetNewsByName(name);
            var news = newModels.Select(_ => ModelMapper.ToDto(_));
            return Response(HttpStatusCode.OK, news);
        }

        // POST api/news
        public HttpResponseMessage Post([FromBody]NewDto dto)
        {
            if (dto == null)
            {
                return Response(HttpStatusCode.BadRequest, "New is null");
            }
            if (dto.NewName.Length < 4 || dto.NewName.Length > 200)
            {
                return Response(HttpStatusCode.BadRequest, "New.NewName length in 4~200");
            }
            var model = ModelMapper.ToModel(dto);
            _service.CreateNew(model);
            bool result = _service.SaveAll();
            if (!result)
            {
                return Response(HttpStatusCode.BadRequest, "New can not save");
            }
            return Response(HttpStatusCode.Created, ModelMapper.ToDto(model));
        }

        // PUT api/news/5
        public HttpResponseMessage Put(int id, [FromBody]NewDto dto)
        {
            if (dto == null)
            {
                return Response(HttpStatusCode.BadRequest, "is null");
            }
            var oldModel = _service.GetNew(id);
            if (oldModel == null)
            {
                return Response(HttpStatusCode.NotFound, "New is not found");
            }
            dto.Id = oldModel.Id;
            if (dto.NewName.Length < 4 || dto.NewName.Length > 200)
            {
                return Response(HttpStatusCode.BadRequest, "New.NewName length in 4~200");
            }
            var model = ModelMapper.ToModel(dto);
            oldModel.NewType = model.NewType;//导航属性需要手动赋值
            _service.UpdateNew(oldModel, model);
            bool result = _service.SaveAll();
            if (!result)
            {
                return Response(HttpStatusCode.BadRequest, "New can not save");
            }
            return Response(HttpStatusCode.OK, ModelMapper.ToDto(oldModel));
        }

        public HttpResponseMessage Put(int id, int state)
        {
            var oldModel = _service.GetNew(id);
            if (oldModel == null)
            {
                return Response(HttpStatusCode.NotFound, "New is not found");
            }
            _service.UpdateNewState(oldModel, state);
            bool result = _service.SaveAll();
            if (!result)
            {
                return Response(HttpStatusCode.BadRequest, "New can not save");
            }
            return Response(HttpStatusCode.OK, ModelMapper.ToDto(oldModel));
        }

        // DELETE api/news/5
        public HttpResponseMessage Delete(int id)
        {
            var oldModel = _service.GetNew(id);
            if (oldModel == null)
            {
                return Response(HttpStatusCode.NotFound, "New is not found");
            }
            _service.DeleteNew(oldModel);
            bool result = _service.SaveAll();
            if (!result)
            {
                return Response(HttpStatusCode.BadRequest, "New can not delete");
            }
            return Response(HttpStatusCode.NoContent);
        }
        //TODO 临时解决浏览器跨域问题
        public HttpResponseMessage Options()
        {
            //发布到iis是需要配置文件handle中remove WebDAV
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Methods", HeaderValue("Access-Control-Request-Method"));
            resp.Headers.Add("Access-Control-Allow-Headers", HeaderValue("Access-Control-Request-Headers"));
            resp.Headers.Add("Access-Control-Max-Age", "60");
            return resp;
        }

    }
}
