using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersControler : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersControler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET api/users
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers([FromQuery]UserParametersDto userParametersDto)
        {
            var userItems = _repository.GetUsers(userParametersDto);
            
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name="GetUserById")]    
        public ActionResult <User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }

            return NotFound();
        }

        // POST /api/users
        [HttpPost]
        public ActionResult <UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {   
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new{Id = userReadDto.Id}, userReadDto);
        }

        // PUT /api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModel = _repository.GetUserById(id);

            if (userModel == null)
            {
                return NotFound();       
            }

            _mapper.Map(userUpdateDto, userModel);

            _repository.UpdateUser(userModel);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH /api/users/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateUser(int id, JsonPatchDocument<UserUpdateDto> userPatchDoc)
        {
            var userModel = _repository.GetUserById(id);

            if (userModel == null)
            {
                return NotFound();       
            }

            // Apply patch doc and validate
            var userToPatch = _mapper.Map<UserUpdateDto>(userModel);

            userPatchDoc.ApplyTo(userToPatch, ModelState);

            if(!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModel);

            _repository.UpdateUser(userModel);

            _repository.SaveChanges();

            return NoContent();

        }

        // DELETE /api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUserById(int id)
        {
            var userModel = _repository.GetUserById(id);

            if (userModel == null)
            {
                return NotFound();       
            }
            _repository.DeleteUser(userModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}