using Microsoft.Data.SqlClient;
using System.Data;

namespace Student_with_Dapper.DATA
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _con;

        public DapperContext(IConfiguration con)
        {
            _con = con;
        }
        public IDbConnection CreateConnection()=> new SqlConnection(_con.GetConnectionString("D"));

    }
}
