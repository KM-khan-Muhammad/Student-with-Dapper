using Student_with_Dapper.Models;

namespace Student_with_Dapper.RPO
{
    public interface IStudent
    {
        Task <IEnumerable<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task<bool> Create(Student student);
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
    }
}
