using System;
using System.Collections.Generic;
using WebAPI_2.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_2.Services{
    public class PersonService : IPersonService
    {
        List<Person> listPerson = new List<Person>{
            new Person (){Id=Guid.NewGuid(), FristName="Ky", LastName="Nguyen Khac", DateOfBirth=new DateTime(1999,12,11), Gender="Male",BirthPlace="Ha Noi"},
            new Person (){Id=Guid.NewGuid(), FristName="Trang", LastName="Huyen Nguyen", DateOfBirth=new DateTime(2002,05,13), Gender="Female",BirthPlace="Hai Phong"},
            new Person (){Id=Guid.NewGuid(), FristName="Pepe", LastName="The Frog", DateOfBirth=new DateTime(2005,03,16), Gender="Male",BirthPlace="Da Nang"},
            new Person (){Id=Guid.NewGuid(), FristName="Tain", LastName="Bep", DateOfBirth=new DateTime(1996,04,15), Gender="Male",BirthPlace="Bac Ninh"},
            new Person (){Id=Guid.NewGuid(), FristName="Ky", LastName="Nguyen Khac", DateOfBirth=new DateTime(1999,12,11), Gender="Male",BirthPlace="Ha Noi"},
        };

        public void Create(Person person)
        {
            person.Id = Guid.NewGuid();
            listPerson.Add(person);
        }
        public List<Person> getAll()
        {
            return listPerson;
        }

        public bool Delete(string name)
        {
            var deletedPerson = listPerson.FirstOrDefault(x => x.FristName == name);
            if(deletedPerson == null){
                return false;
            }
            listPerson.Remove(deletedPerson);
            return true;
        }

        public void Update(Guid id, Person person)
        {
            var updatePerson = listPerson.FirstOrDefault(x => x.Id == id);
            // if(updatePerson == null){
            //     return BadRequestResult;
            // }
            updatePerson.FristName = person.FristName;
            updatePerson.LastName = person.LastName;
            updatePerson.DateOfBirth = person.DateOfBirth;
            updatePerson.Gender = person.Gender;
            updatePerson.BirthPlace = person.BirthPlace;

        }
        public List<Person> Filter(string sortBy, string value)
        {
            List<Person> filterList = new List<Person>();
            if(sortBy.Equals("Name", StringComparison.CurrentCultureIgnoreCase)){
                filterList = listPerson.Where(x => x.FullName().Contains(value)).ToList();
            }
            else if(sortBy.Equals("Gender", StringComparison.CurrentCultureIgnoreCase)){
                filterList= listPerson.Where(x => x.Gender.Equals(value, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            else if(sortBy.Equals("BirthPlace", StringComparison.CurrentCultureIgnoreCase)){
                filterList = listPerson.Where(x => x.BirthPlace.Equals(value, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            else{
                filterList = null;
            }
                  
            return filterList;
        }


    }
}