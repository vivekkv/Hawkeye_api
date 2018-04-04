namespace hawkeye_api.Models
{
    using System.Collections.Generic;
    using Cassandra;
    
    public interface ICassandraCore
    {
        ISession GeSession(KeySpaces keyspace);

        List<Row> GetData(string query, KeySpaces keyspace);
    }
}
