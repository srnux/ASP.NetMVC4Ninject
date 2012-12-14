using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonModel;
using System.Data.Entity;
using System.Data;

namespace PersonRepository
{
    public class PersonRepository:RepositoryBase<PersonDBContext>, IRepositoryMethods<Person>
    {
 
        public IQueryable<Person> All
        {
            get { return DataContext.People; }
        }

        public IQueryable<Person> AllIncluding(params System.Linq.Expressions.Expression<Func<Person, object>>[] includeProperties)
        {
            IQueryable<Person> query = DataContext.People;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Person Find(long id)
        {
            return DataContext.People.Find(id);
        }

        public void InsertOrUpdate(Person person)
        {
            if (person.Id == default(long))
            {
                // New entity
                DataContext.People.Add(person);
            }
            else
            {
                // Existing entity
                //DataContext.Entry(person).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var agent = DataContext.People.Find(id);
            DataContext.People.Remove(agent);
        }
    }
}
