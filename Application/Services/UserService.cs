using HealthPlus.Application.DTOs;
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

        public BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password)
        {
            var user = _repository.Get<User>(x => x.Id == id);

            if (password.Password != null)
            {
                if (password.Password == password.ConfirmPassword)
                {
                    user.Password = password.Password;
                }
                else
                {
                    return new BaseResponse
                    {
                        Message = "Passwords do not match",
                        Status = false
                    };
                }
            }
            else
            {
                return new BaseResponse
                {
                    Message = "Password is empty. Enter Password",
                    Status = false
                };
            }

            var userUpdate = _repository.Update<User>(user);
            _repository.SaveChanges();

            if (userUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Unable to update password",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Password updated successfully",
                Status = true
            };
        }

        // public UserResponseModel LogIn(string email, string password)
        // {
        //     throw new NotImplementedException();
        // }

        public BaseResponse Login(string email, string password)
        {
            var user = _repository.Get<User>(x => x.Email== email);
            if(user != null && user.Password == password)
            {
                return new BaseResponse
                {
                    Message = "Login successful",
                    Status = true
                };
            }
            else if(user != null)
            {
                return new BaseResponse
                {
                    Message = "Incorrect Password",
                    Status = false
                };
            }

            return new BaseResponse
            {
                Message = $"User not found with email {email}",
                Status = false
            };
            
        }
    }
}
