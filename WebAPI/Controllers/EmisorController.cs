using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors; 

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Emisor")]
    public class EmisorController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.Emisor emisor)
        {
            var result = BL.Emisor.Add(emisor);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("Update/{idEmisor?}")]
        [HttpPut]
        public IHttpActionResult Update(int idEmisor, [FromBody] ML.Emisor emisor)
        {
            emisor.IdEmisor = idEmisor;
            var result = BL.Emisor.Update(emisor);
            if (result != null)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("Delete/{idEmisor?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idEmisor)
        {
            var result = BL.Emisor.Delete(idEmisor);
            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var list = BL.Emisor.GetAll();
            if (list != null)
            {
                return Content(HttpStatusCode.OK, list);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, list);
            }
        }
        [Route("GetById/{idEmisor?}")]
        [HttpGet]
        public IHttpActionResult GetById(int idEmisor)
        {
            var list = BL.Emisor.GetById(idEmisor);
            if (list != null)
            {
                return Content(HttpStatusCode.OK, list);

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, list);
            }
        }
    }
}
