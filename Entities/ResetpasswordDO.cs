namespace Entities
{
    public partial class ResetPasswordDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; } = null!;
        public string Guid { get; set; } = null!;
        public DateTime? Lastdate { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual UserDO User { get; set; } = null!;
    }
}
