using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyCOntroller : APIController
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BuggyCOntroller(DataContext context, UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
            this._context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecrect()
        {
            return "secret text!";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            return GetServerError();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is not a good request!");
        }
    }
}