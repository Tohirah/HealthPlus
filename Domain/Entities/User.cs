﻿using HealthPlus.Domain.Enum;

namespace HealthPlus.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Salt { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();






    }
}
