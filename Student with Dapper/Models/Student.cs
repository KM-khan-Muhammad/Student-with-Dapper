namespace Student_with_Dapper.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; }  
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
