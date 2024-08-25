public interface IPersonRepository
{

	IEnumerable<Person> GetPersons();

	Person? GetPersonByID(int? personID);

	void InsertPerson(Person person);

	void UpdatePerson(Person person);

	void DeletePerson(Person person);

	void DeletePersonById(int? Id);

	Person DeletePersonByIdTWO(int Id);

	void Save();
}