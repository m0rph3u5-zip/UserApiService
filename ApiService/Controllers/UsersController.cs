using System;
using System.Collections.Generic;
using ApiService.Core;
using ApiService.Manager;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager _userManager;

        public UsersController(UserManager userManage)
        {
            _userManager = userManage;
        }

        // GET All Users
        [HttpGet]
        [Route("all")]
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                return Ok(_userManager.GetAll());
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // GET api/values/5
        [HttpGet]
        [Route("get/{id:length(24)}")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                if (id == null)
                {
                    User user = new User();
                    user = _userManager.GetById(id);
                    if (user == null)
                        return StatusCode(404, "Nessun utete trovato!");
                    else
                        return Ok(user);
                }
                else
                {
                    return StatusCode(404, "Nessun utete trovato!");
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Insert([FromBody] User user)
        {
            if (user == null)
                return StatusCode(404, "Nessun ");
            return Ok(_userManager.Insert(user));
        }

        // PUT api/values/5
        [HttpPost]
        public void Update(string id, [FromBody] User user)
        {

        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(string id)
        {

        }
    }
}
