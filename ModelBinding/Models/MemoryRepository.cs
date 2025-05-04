
using System.Text;

namespace ModelBinding.Models;

public class MemoryRepository : IRepository
{
    private Dictionary<int, Person> people = new Dictionary<int, Person>()
    {
        [1] = new Person
        {
            PersonId = 1,
            FirstName = "Eduard",
            LastName = "Snow",
            Role = Role.Admin,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"
                
            }
        },
        [2] = new Person
        {
            PersonId = 2,
            FirstName = "Charles",
            LastName = "Rolls",
            Role = Role.User,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"

            }
        },
        [3] = new Person
        {
            PersonId = 3,
            FirstName = "Hanry",
            LastName = "Royce",
            Role = Role.User,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"

            }
        },
        [4] = new Person
        {
            PersonId = 4,
            FirstName = "Cillian",
            LastName = "Murhpy",
            Role = Role.Guest,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"

            }
        },
        [5] = new Person
        {
            PersonId = 5,
            FirstName = "Robert",
            LastName = "Oppenheimer",
            Role = Role.Guest,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"

            }
        },
        [6] = new Person
        {
            PersonId = 6,
            FirstName = "James",
            LastName = "Gandolfini",
            Role = Role.Guest,
            HomeAddress = new Address()
            {
                City = "Washington",
                Country = "USA"

            }
        }
    };

    public Person this[int id]
    {
        get { return people.ContainsKey(id) ? people[id] : null; }
        set { people[id] = value; }
    }

    public IEnumerable<Person> People => people.Values;
}
