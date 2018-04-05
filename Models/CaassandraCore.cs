namespace hawkeye_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cassandra;

    public class CassandraCore : ICassandraCore
    {
        private List<string> _ipCollections;

        private Dictionary<int, ISession> _sessions { get; set; }

        public CassandraCore(string connectionString)
        {
            _sessions=new Dictionary<int, ISession>();
            _ipCollections = new List<string>();

            var hosts = connectionString.Split(",");
            _ipCollections.AddRange(hosts);
        }

        public ISession GeSession(KeySpaces keyspace)
        {
            ISession session;
            if (_sessions.ContainsKey((int)keyspace))
            {
                _sessions.TryGetValue((int)keyspace, out session);
                return session ?? BuildSession(keyspace);
            }
            return BuildSession(keyspace);

        }

        public List<Row> GetData(string query, KeySpaces keyspace)
        {
            List<Row> result=new List<Row>();
            
            try
            {
                var session = this.GeSession(keyspace);
                result = session.Execute(query).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return result;
        }

        private ISession BuildSession(KeySpaces keyspace)
        {
            var clustor = Cluster.Builder().AddContactPoints(_ipCollections).Build();
            var session = clustor.Connect(keyspace.ToString());

            if (_sessions.ContainsKey((int)keyspace))
            {
                _sessions.Remove((int)keyspace);
            }

            _sessions.TryAdd((int)keyspace, session);
            return session;
        }
    }
}