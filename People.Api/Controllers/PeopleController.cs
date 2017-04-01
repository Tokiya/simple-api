using People.Api.Models;
using People.Api.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace People.Api.Controllers
{
    [RoutePrefix("api/{appid}/people")]
    public class PeopleController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult All(string appid)
        {
            try
            {
                var repo = new InMemoryRepository(appid);
                return Json(new { data = repo.GetAll() });
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{name}")]
        public IHttpActionResult AllByName(string appid, string name)
        {
            try
            {
                var repo = new InMemoryRepository(appid);
                return Json(new { data = repo.GetAll(p => p.firstname == name) });
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult ById(string appid, int id)
        {
            try
            {
                var repo = new InMemoryRepository(appid);
                return Json(repo.Get(id));
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(string appid,int id) 
        {

            try
            {
                var repo = new InMemoryRepository(appid);
                repo.Delete(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(string appid,[FromBody] Person person)
        {
            try
            {
                var repo = new InMemoryRepository(appid);
                repo.Add(person);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(string appid, [FromBody] Person person)
        {
            try
            {
                var repo = new InMemoryRepository(appid);
                repo.Update(person);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
