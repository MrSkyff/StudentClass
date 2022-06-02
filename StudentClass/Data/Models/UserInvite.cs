using System.ComponentModel.DataAnnotations;

namespace StudentClass.Data.Models
{
    public class UserInvite
    {
        [Key]
        public int Id { get; set; }
        public string? InviteCode { get; set; }
        public string? EMail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime UseDate { get; set; }
        public string? CreatedBy { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
    }
    public enum InviteStatus
    {
        Active,
        Inactive,
        Used,
        Expired,
    }
}
