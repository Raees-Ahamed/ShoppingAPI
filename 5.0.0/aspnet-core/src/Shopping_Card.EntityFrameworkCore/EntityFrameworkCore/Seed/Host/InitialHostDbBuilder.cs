namespace Shopping_Card.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly Shopping_CardDbContext _context;

        public InitialHostDbBuilder(Shopping_CardDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
