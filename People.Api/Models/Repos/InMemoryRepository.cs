using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People.Api.Models.Repos
{
    public class InMemoryRepository
    {
        static Dictionary<string, List<Person>> _inMemoryPeople = new Dictionary<string, List<Person>>();

        List<Person> _people;
        string _key;

        public InMemoryRepository(string key)
        {
            _people = _inMemoryPeople[key];
        }

        public static void Reset()
        {
            _inMemoryPeople.Clear();
            GC.Collect();
        }

        public IEnumerable<Person> GetAll(Func<Person,bool> condition = null) 
        {
            if (condition == null) return _people;
            return _people.Where(condition);
        }

        public Person Get(int id) 
        {
            return _people.FirstOrDefault(p => p.id == id);
        }

        public void Add(Person p) 
        {
            p.id = _people.Select(x => x.id).Max() + 1;
            _people.Add(p);
        }

        public void Delete(int id) 
        {
            var person = _people.FirstOrDefault(p => p.id == id);
            if (person == null) return;
            _people.Remove(person);
        }

        public void Update(Person personToUpdate) 
        {
            var person = _people.FirstOrDefault(p => p.id == personToUpdate.id);
            if (person == null) return;
            person.age = personToUpdate.age;
            person.firstname = personToUpdate.firstname;
            person.lastname = personToUpdate.lastname;
        }


        public static void AddKey(string key) 
        {
            var people = new List<Person> 
            {
                new Person
                {
                    age=17,
                    firstname="karen",
                    id=1,
                    lastname="cox",
                    image=
                        new Photo
                        {
                            large="https://randomuser.me/api/portraits/women/85.jpg",
                            medium="https://randomuser.me/api/portraits/med/women/85.jpg",
                            small="https://randomuser.me/api/portraits/thumb/women/85.jpg"
                        }
                    
                },

                new Person
                {
                    age=19,
                    firstname="zoe",
                    id=2,
                    lastname="castillo",
                    image=
                        new Photo
                        {
                            large="https://randomuser.me/api/portraits/women/35.jpg",
                            medium="https://randomuser.me/api/portraits/med/women/35.jpg",
                            small="https://randomuser.me/api/portraits/thumb/women/35.jpg"
                        }
                    
                },

                new Person
                {
                    age=17,
                    firstname="alice",
                    id=3,
                    lastname="wallace",
                    image=
                        new Photo
                        {
                            large="https://randomuser.me/api/portraits/women/71.jpg",
                            medium="https://randomuser.me/api/portraits/med/women/71.jpg",
                            small="https://randomuser.me/api/portraits/thumb/women/71.jpg"
                        }
                },

                new Person
                {
                    age=17,
                    firstname="victor",
                    id=4,
                    lastname="gilbert",
                    image=
                        new Photo
                        {
                            large="https://randomuser.me/api/portraits/men/4.jpg",
                            medium="https://randomuser.me/api/portraits/med/men/4.jpg",
                            small="https://randomuser.me/api/portraits/thumb/men/4.jpg"
                        }
                },

                new Person
                {
                    age=17,
                    firstname="randall",
                    id=5,
                    lastname="fuller",
                    image=
                        new Photo
                        {
                            large="https://randomuser.me/api/portraits/men/93.jpg",
                            medium="https://randomuser.me/api/portraits/med/men/93.jpg",
                            small="https://randomuser.me/api/portraits/thumb/men/93.jpg"
                        }
                }
            };

            _inMemoryPeople[key] = people;
        }
    }
}