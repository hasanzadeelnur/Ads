using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsForMoney.DTO
{
    public class AddAdsDTO
    {
        public IFormFile file { get; set; }
        public string header { get; set; }
        public string content { get; set; }
    }
}
