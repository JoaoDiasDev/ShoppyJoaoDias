namespace DAL.MySqlDbContext
{
    public partial class ResetPassword
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string Email { get; set; } = null!;
        public string Guid { get; set; } = null!;
        public DateTime? Lastdate { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
