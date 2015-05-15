using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spartan.Services.Interface;
using Spartan.Model.Models;

namespace Spartan.Api.Dto.Mapper
{
    //TODO 用更好的方式来实现
    public class ModelMapperFactory
    {
        private IService _service;

        public ModelMapperFactory(IService _service)
        {
            this._service = _service;
        }
        public News ToModel(NewDto d)
        {
            if (d == null)
            {
                return null;
            }
            var model = new News
            {
                Id = d.Id,
                NewName = d.NewName,
                NewContent = d.NewContent,
                NewTime = d.NewTime,
                State = d.State,

            };
            if (d.NewType != null)
            {
                model.NewType = (_service as INewService).GetNewType(d.NewType.Id);
            }
            return model;
        }

        public NewDto ToDto(News t)
        {
            if (t == null)
            {
                return null;
            }
            var dto = new NewDto
            {
                Id = t.Id,
                NewName = t.NewName,
                NewTime = t.NewTime,
                NewContent = t.NewContent,
                NewType = ToDto(t.NewType),
                State = t.State
            };
            return dto;
        }
        public NewType ToModel(NewTypeDto d)
        {
            if (d == null)
            {
                return null;
            }
            var model = new NewType
            {
                Id = d.Id,
                Name = d.TypeName
            };
            return model;
        }

        public NewTypeDto ToDto(NewType t)
        {
            if (t == null)
            {
                return null;
            }
            var dto = new NewTypeDto
            {
                Id = t.Id,
                TypeName = t.Name
            };
            return dto;
        }
    }
}