using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; } = false;
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int UserRoleId { get; set; }
        public virtual AppUserRole UserRole { get; set; }
    }
}