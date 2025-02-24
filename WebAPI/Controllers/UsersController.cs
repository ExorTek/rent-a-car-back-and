﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("mostrented")]
        public IActionResult GetMostRentedUser()
        {
            var result = _userService.GetMostRentedUser();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("count")]
        public IActionResult GetAllUsersCount()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data.Count);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UserForUpdateDto userForUpdateDto)
        {
            var result = _authService.Update(userForUpdateDto.User, userForUpdateDto.Password);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlastregister")]
        public IActionResult GetLastRegisterUser()
        {
            var result = _userService.GetLastRegisterUser();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("updateforauthorized")]
        public IActionResult UpdateForAuthorized(UserUpdateForAuthorizedDto userUpdateForAuthorized)
        {
            var result = _userService.UpdateForAuthorized(userUpdateForAuthorized);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserbyemail")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getuserfindeks")]
        public IActionResult GetUserFindeks([FromBody] UserFindeksDto userFindeksDto)
        {
            var result = _userService.GetUserFindeks(userFindeksDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getuserclaims")]
        public IActionResult GetUserClaims(int id)
        {
            var result = _userService.GetClaims(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}