using Microsoft.EntityFrameworkCore;
public class PersonRepository : IPersonRepository
{
	private readonly PersonContext _dbContext;
	public PersonRepository(PersonContext dbContext)
	{
		_dbContext = dbContext;
	}
	public void Save()
	{
		_dbContext.SaveChanges();
	}
	public IEnumerable<Person> GetPersons()
	{
		return _dbContext.Persons.ToList();
	}
	public Person? GetPersonByID(int? personId)
	{
		return _dbContext.Persons.Find(personId is not null ? personId : 0);
	}
	public void InsertPerson(Person person)
	{
		_dbContext.Add(person);
		Save();
	}
	public void UpdatePerson(Person person)
	{
		_dbContext.Entry(person).State = EntityState.Modified;
		Save();
	}
	public void DeletePerson(Person person)
	{
		//		Fetch the person to delete by the Id
		var personEntity = _dbContext.Persons.Where(e => e.Id == person.Id).FirstOrDefault();
		if (personEntity is null) return;
		_dbContext.Persons.Remove(personEntity);
		// 	Save the changes.
		_dbContext.SaveChanges();
	}
	public void DeletePersonById(int? Id)
	{
		//		Fetch the person to delete by the Id
		var personEntity = _dbContext.Persons.Where(e => e.Id == Id).FirstOrDefault();

		if (personEntity is null) return;

		_dbContext.Persons.Remove(personEntity);
		// 	Save the changes.
		_dbContext.SaveChanges();
	}

	public Person DeletePersonByIdTWO(int Id)
	{
		//		Fetch the person to delete by the Id
		var personEntity = _dbContext.Persons.Where(e => e.Id == Id).FirstOrDefault();

		if (personEntity is null) return new Person();

		_dbContext.Persons.Remove(personEntity);
		//	Save the changes.
		_dbContext.SaveChanges();

		return personEntity;
	}

}