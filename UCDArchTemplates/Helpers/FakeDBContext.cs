using UCDArch.Core.PersistanceSupport;

namespace UCDArchTemplates.Helpers
{
    public class FakeDBContext : IDbContext
    {
        public void CommitChanges()
        {
            
        }

        public void BeginTransaction()
        {
            
        }

        public void CommitTransaction()
        {
            
        }

        public void RollbackTransaction()
        {
            
        }

        public bool IsActive
        {
            get
            {
                return true;
            }
        }
    }
}