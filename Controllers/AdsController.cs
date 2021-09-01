using AdsForMoney.Database;
using AdsForMoney.DTO;
using AdsForMoney.Libs;
using AdsForMoney.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsForMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        DataContext _db;
        public AdsController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("GetAds")]
        public IActionResult GetAds()
        {
            List<AdsModel> data = _db.AdsModels.ToList();
            return Ok(data);
        }
        [HttpPost]
        [Route("PostAds")]
        public IActionResult PostAds([FromForm] AddAdsDTO request)
        {
            string path = "";
            if (request.file is object)
            {
                string paths = $"{request.content}-{Guid.NewGuid().ToString("D").Substring(0, 8).ToUpper()}";
                path = FileManager.IFormSave(request.file, paths);
            }
            AdsModel response = new AdsModel();
            response.content = request.content;
            response.header = request.header;
            response.view = path;
            _db.AdsModels.Add(response);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteAds/{id}")]
        public IActionResult DeleteAds(int id)
        {
            AdsModel data = _db.AdsModels.Find(id);
            _db.AdsModels.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }

        [HttpPut]
        [Route("PutAds")]
        public IActionResult PutAds([FromBody] AdsModel ads)
        {
            AdsModel data = _db.AdsModels.Find(ads.id);
            data.view = ads.view;
            data.header = ads.header;
            data.content = ads.content;
            _db.SaveChanges();
            return Ok(data);


        }



    }
}
