using System;
using Spartan.Model.Base;
using Spartan.Model.DbContext;
using Spartan.Model.Models;
using Spartan.Services.Interface;
using Spartan.Api.Dto.Mapper;

namespace Spartan.Api.Dto
{
    public class NewDto
    {

        public int Id { get; set; }

        public string NewName { get; set; }

        public DateTime NewTime { get; set; }

        public string NewContent { get; set; }

        public NewTypeDto NewType { get; set; }

        public int State { get; set; }


    }
}
