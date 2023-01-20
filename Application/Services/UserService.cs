﻿using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;
using System.Linq.Expressions;

namespace HealthPlus.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository) 
        {
            _repository = repository;
        }

        public BaseResponse CreateRole(CreateRoleRequestModel request)
        {
            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };
            _repository.Add<Role>(role);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "New Role Created Successfully",
                Status = true
            };
        }

        public RoleResponseModel GetRoleById(int id)
        {
            var role = _repository.Get<Role>(x => x.Id == id);
            if (role == null)
            {
                return new RoleResponseModel
                {
                   Message = $"No Record found with Id {id}",
                   Status = false
                };
            }
            return new RoleResponseModel
            {
                Name = role.Name,
                Description = role.Description,
                Status = true
            };
        }

        public IList<RoleResponseModel> GetRoles()
        {
            var roles = _repository.GetAll<Role>();
            
            var roleResponse = roles.Select(x => new RoleResponseModel() {
                Name = x.Name,
                Description = x.Description,
                Status = true
            }).ToList();
           
            return roleResponse;
        }

        public RoleResponseModel GetRoleByName(string name)
        {
            var role = _repository.Get<Role>(x => x.Name == name);
            
            if(role == null)
            {
                return new RoleResponseModel
                {
                    Message = $"No role found with name {name}",
                    Status = false
                };
            }
            return new RoleResponseModel
            {
                Name = role.Name,
                Description = role.Description,
                Status =true
            };
        }

        public UserResponseModel GetUserById(int id)
        {
            var user = _repository.Get<User>(x => x.Id == id);
            if (user == null)
            {
                return new UserResponseModel
                {
                    Message = "No user found with Id {id}",
                    Status = false
                };
            }
            return new UserResponseModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Status = true

            };
        }

        public UserResponseModel GetUserByUsername(string name)
        {
            var user = _repository.Get<User>(x => x.UserName == name);
            
            if(user == null)
            {
                return new UserResponseModel
                {
                    Message = $"No role found with name {name}",
                    Status = false
                };
            }
            return new UserResponseModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Status = true

            };

        }

        public IList<UserResponseModel> GetUsers()
        {
            var users = _repository.GetAll<User>();

            var userResponse = users.Select(x => new UserResponseModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                Address = x.Address,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Password = x.Password
            }).ToList();

            return userResponse;
        }
    }
}