using ApiService.Core;
using ApiService.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManage)
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
                List<User> resultUser = _userManager.GetAll();
                if (resultUser.Count <= 0)
                    return NotFound();
                return Ok(resultUser);
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // GET api/values/5
        [HttpGet]
        [Route("get/{id}")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                if (id == null)
                {
                    User user = _userManager.GetById(id);
                    if (user == null)
                        return NotFound();
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("insert")]
        public ActionResult<User> Insert([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();
                return Ok(_userManager.Insert(user));
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // PUT api/values/5
        [HttpPost]
        [Route("update")]
        public ActionResult Update(string id, [FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();
                return Ok(_userManager.Update(user));
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return BadRequest();
                if (_userManager.GetById(id) != null)
                    return NotFound();
                _userManager.Delete(id);
                return NoContent();
            }
            catch (Exception Ex)
            {
                return StatusCode(500, Ex);
            }
        }
    }
}
