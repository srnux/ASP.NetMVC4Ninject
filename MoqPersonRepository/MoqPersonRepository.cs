using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonModel;
using PersonRepository;
namespace MoqPersonRepository
{
    public class MoqPersonRepository:IRepositoryMethods<Person>
    {
        protected List<Person> _people;
        public List<Person> People { get { return _people; } }

        public MoqPersonRepository()
        {
            _people = new List<Person>();
            Person p=new Person();
            p.Id = 1;
            p.Name="Luke";
            p.Surname="Skywalker";
            p.Age=77;
            _people.Add(p);

            p = new Person();
            p.Id = 2;
            p.Name = "Han";
            p.Surname = "Solo";
            p.Age = 114;
            _people.Add(p);

            p = new Person();
            p.Id = 3;
            p.Name = "Obi-Wan";
            p.Surname = "Kenobi";
            p.Age = 114;
            _people.Add(p);

        }

        public IQueryable<Person> All
        {
            get { return People.AsQueryable<Person>(); }
        }

        public IQueryable<Person> AllIncluding(params System.Linq.Expressions.Expression<Func<Person, object>>[] includeProperties)
        {
            return People.AsQueryable<Person>();
        }

        public Person Find(long id)
        {
            return People.Find(p=>p.Id==id);
        }

        public void InsertOrUpdate(Person accesslevel)
        {
            
        }

        public void Delete(long id)
        {
            
        }

        public void Save()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
