namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options):base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=True;");

                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
