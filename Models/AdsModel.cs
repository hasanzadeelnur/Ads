using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdsForMoney.Models
{
    public class AdsModel
    {
        [Key]
        public int id { get; set; }
        public string view { get; set; }
        public string header { get; set; }
        public string content { get; set; }


    }
}
