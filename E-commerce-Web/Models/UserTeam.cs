namespace AGRISmartPro.Models
{
    public class UserTeam
    {
        public int UserTeamId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }

        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}