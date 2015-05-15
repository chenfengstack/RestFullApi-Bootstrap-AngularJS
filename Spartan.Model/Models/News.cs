using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Spartan.Model.Base;

namespace Spartan.Model.Models
{
    [Table("news")]
    public class News : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string NewName { get; set; }

        public DateTime NewTime { get; set; }

        public string NewContent { get; set; }

        public NewType NewType { get; set; }

        public int State { get; set; }
    }
}
