using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController:Controller
    {
        private readonly IdatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IdatingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users =await  _repo.GetUsers();
            var userToReturn=_mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var users =await  _repo.GetUser(id);
            var userToReturn=_mapper.Map<UserForDetailDto>(users);
            return Ok(userToReturn);
        }
    }
}