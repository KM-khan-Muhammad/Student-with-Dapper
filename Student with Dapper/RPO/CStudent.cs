using Dapper;
using Student_with_Dapper.DATA;
using Student_with_Dapper.Models;
using System.Collections;

namespace Student_with_Dapper.RPO
{
    public class CStudent : IStudent
    {
        private readonly IDapperContext _con;

        public CStudent(IDapperContext con)
        {
            _con = con;
        }
        public async Task<bool> Create(Student student)
        {
            var data= @" INSERT INTO Students (Name, Email, Age, CreatedDate)
                VALUES (@Name, @Email, @Age, GETDate())";
            using var connection =   _con.CreateConnection();
            var result =await connection.ExecuteAsync(data, student);
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
             var data=" DELETE FROM Students WHERE Id = @Id";
            using var connection =  _con.CreateConnection();
            var result =await connection.ExecuteAsync(data, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
             var data=" SELECT * FROM Students ORDER BY CreatedDate DESC";
            using var connection = _con.CreateConnection();
            return await connection.QueryAsync<Student>(data);
        }

        public async Task<Student?> GetStudentById(int id)
        {
             var data=" SELECT * FROM Students WHERE Id = @Id";
            using var connection = _con.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Student>(data, new { Id = id });
        }

        public async Task<bool> Update(Student student)
        {
            var data= @"
                UPDATE Students 
                SET Name = @Name, Email = @Email, Age = @Age
                WHERE Id = @Id";
            using var connection = _con.CreateConnection();
            var result = await connection.ExecuteAsync(data, student);
            return result > 0;
        }
    }
}
