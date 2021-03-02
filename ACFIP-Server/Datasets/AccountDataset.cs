using ACFIP_Server.Models;

namespace ACFIP_Server.Datasets
{
    public class AccountDataset
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public bool Status { get; set; }
    }
    public class LoginDataset
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
    public class RegisterDataset
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
