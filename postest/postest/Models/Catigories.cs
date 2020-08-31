using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postest.Models
{
    public class Catigories
    {
        [Key]
        public int CAT_ID { set; get; }
        [Required(ErrorMessage ="لازم تدخلو")]
        public string Desc { set; get; }

        public ICollection<Items> Items { set; get; }
    }
}
