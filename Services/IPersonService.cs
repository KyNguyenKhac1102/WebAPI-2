using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_2.Models;

namespace WebAPI_2.Services{
    public interface IPersonService{
        List<Person> getAll();
        void Create(Person person);
        void Update(Guid id, Person person);
        bool Delete(string name);
        List<Person> Filter(string sortBy, string value);
    }
}