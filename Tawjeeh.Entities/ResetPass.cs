namespace Tawjeeh.Entities
{
    public class ResetPass
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
