using System.Data;

namespace Student_with_Dapper.DATA
{
      public interface IDapperContext
      {
          IDbConnection CreateConnection();
      }
     
}
