namespace CrudAPI_Sqlite.Models;

public class Person
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
}
