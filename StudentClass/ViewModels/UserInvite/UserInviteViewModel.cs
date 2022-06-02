using Microsoft.AspNetCore.Mvc;
using StudentClass.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentClass.ViewModels.UserInvite
{
    public class UserInviteViewModel
    {
        public int Id { get; set; }
        public string? InviteCode { get; set; }
        [Remote(action: "IsEmailNotExist", controller: "UserInvite", ErrorMessage = "Email already used!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email not valid!")]
        [Required(ErrorMessage = "Email is not set!")]
        public string? EMail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime UseDate { get; set; }
        public string? CreatedBy { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Role>? RoleSelector { get; set; }
    }
}
