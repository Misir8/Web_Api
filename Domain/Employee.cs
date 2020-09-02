namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Price { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}