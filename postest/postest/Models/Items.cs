using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postest.Models
{
    public class Items
    {
        [Key]
        public int ITEM_ID { set; get; }

        public int CAT_ID { set; get; }

        [EmailAddress(ErrorMessage = "this ic nice")]
        public string EMAIL { set; get; }

        public Catigories Catigories { set; get; }
    }
}
