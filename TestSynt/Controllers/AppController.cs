using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSynt.Models;
using TestSynt.Repositorys;

namespace TestSynt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IAppRepository appRepository;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public AppController(IAppRepository appRepository)
        {

            this.appRepository = appRepository;
        }


        // GET: App
        [HttpGet]
        public ActionResult<List<AppModel>> GetAll()
        {
            return Ok(appRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AppModel> GetById(int id)
        {
            AppModel data = appRepository.GetById(id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);

            }

        }


        [HttpPut]
        public ActionResult Update(AppModel data)
        {
            try
            {
                appRepository.Update(data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }


        [HttpPost]
        public ActionResult Create(AppModel data)
        {
            try
            {
                appRepository.Create(data);

                return Ok(new MessageModel { Code = 1, Msg = "Ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageModel { Code = 2, Msg = ex.Message });

            }

        }


    }
}