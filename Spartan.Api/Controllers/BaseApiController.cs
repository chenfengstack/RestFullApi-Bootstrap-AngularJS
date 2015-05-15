using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Spartan.Framework.Config;
using Spartan.Framework.Util;
using Spartan.Model.Base;
using Spartan.Model.DbContext;
using Spartan.Services.Base;
using Spartan.Services.Interface;
using Spartan.Api.Common;
using Spartan.Api.Dto.Mapper;

namespace Spartan.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ModelMapperFactory ModelMapper;
        public BaseApiController(IService service)
        {
            ModelMapper = new ModelMapperFactory(service);
        }

        protected T PageListResult<T>(T t, int totalCount, int totalPage)
        {
            HttpContext.Current.Response.Headers.Add("X-Pages-Count", totalCount.ToString());
            HttpContext.Current.Response.Headers.Add("X-Pages-Pages", totalPage.ToString());
            return t;
        }

        public string HeaderValue(string key)
        {
            return HttpContext.Current.Request.Headers.AllKeys.Any(_ => _.Equals(key)) ? HttpContext.Current.Request.Headers[key] : "";
        }

        //protected int PageIndex
        //{
        //    get
        //    {
        //        return StringUtil.ToInt32(HeaderValue(ApiConfig.PageIndex));
        //    }
        //}

        //protected int PageSize
        //{
        //    get
        //    {
        //        return StringUtil.ToInt32(HeaderValue(ApiConfig.PageSize), SysConfig.PAGE_MIN_SIZE, SysConfig.PAGE_MAX_SIZE);
        //    }
        //}

        protected HttpResponseMessage Response<T>(HttpStatusCode code, T value)
        {
            return Request.CreateResponse(code, value);
        }
        protected HttpResponseMessage Response(HttpStatusCode code, string message)
        {
            return Request.CreateResponse(code, new ErrorMessage { Message = message });
        }
        protected HttpResponseMessage Response(HttpStatusCode code)
        {
            return Request.CreateResponse(code);
        }
    }
}