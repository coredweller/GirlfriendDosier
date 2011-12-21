using Core.Helpers;
using System.Data.Linq;

namespace EData.Repository
{
    public class RelationshipsDatabaseFactory : IRelationshipsDatabaseFactory
    {

        private readonly string _connectionString;
        private readonly ILogWriter _logWriter;
        public IRelationshipsDatabase _database;

        public RelationshipsDatabaseFactory(IConnectionString connectionString, ILogWriter logWriter)
        {
            Checks.Argument.IsNotNull(connectionString, "connectionString");

            _connectionString = connectionString.Value;
            _logWriter = logWriter;
        }


        #region IRelationshipsDatabaseFactory Members

        public IRelationshipsDatabase Get()
        {
            if (_database == null)
            {
                DataLoadOptions options = new DataLoadOptions();

                //options.LoadWith<Tour>(tour => tour.Shows);

                




                //NEEED TO UCOMMENT THIS
                _database = new RelationshipsDatabase( _connectionString )
                    { 
                         
                        //LoadOptions = options, 
                        //DeferredLoadingEnabled = true, 
                        //Log = (_logWriter == null ? null : _logWriter.Get()) 
                    };
            }

            return _database;
        }

        #endregion
    }
}
