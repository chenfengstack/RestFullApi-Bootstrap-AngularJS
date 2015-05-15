using Spartan.Model.Base;
using Spartan.Model.DbContext;
using Spartan.Model.Models;

namespace Spartan.Api.Dto
{
    public class NewTypeDto
    {
        public int Id { get; set; }

        public string TypeName { get; set; }
    }
}
