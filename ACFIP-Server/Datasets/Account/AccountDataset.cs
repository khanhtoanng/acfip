using ACFIP_Server.Models;

namespace ACFIP_Server.Datasets.Account
{
    public class AccountDataset
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public bool Status { get; set; }
    }
}
