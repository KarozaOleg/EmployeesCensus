using EmployeesCensus.Models;

namespace EmployeesCensus.Repositories
{
    public class DbRepository
    {
        private static EmployeesCensusContext Db;    
        
        private DbRepository()
        {
        }

        public static EmployeesCensusContext GetInstance()
        {
            if (Db == null)
                Db = new EmployeesCensusContext();
            return Db;
        }
    }
}