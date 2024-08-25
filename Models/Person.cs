public class Person
{
	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? SSN { get; set; }
	public DateTime InsertDte_sys { get; set; }
	public DateOnly DOB_sys { get; set; }
	public TimeOnly WorkStartsAt_sys { get; set; }
	public DateTimeOffset CurrentTime_sys { get; set; }
}