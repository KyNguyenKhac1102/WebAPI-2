using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI_2.Models;
using WebAPI_2.Services;
using System.Text;
using System.Text.Json;
namespace WebAPI_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;
        private readonly ILogger<PersonService> _logger;


        public PersonController(ILogger<PersonService> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        // GET: api/Person

        [HttpGet]
        public List<Person> GetPerson(){   
            return _personService.getAll();
        }
        // POST: api/Person
        [HttpPost]

        public StatusCodeResult Person(Person person){
            
             _personService.Create(person);
            return StatusCode(200);
        }

        [HttpPut("")]
        public List<Person> Person(Guid id, Person person){
            _personService.Update(id, person);
            return _personService.getAll();
        }

        [HttpDelete("{name}")]
        public StatusCodeResult Person(string name){
           var isDeleted = _personService.Delete(name);
           if(isDeleted){
                return StatusCode(200);
           }
            return StatusCode(404);
        }

        [HttpGet("{sortBy}")]
        public IActionResult Filter(string sortBy, string value){
            
            if(_personService.Filter(sortBy, value) == null){
                return StatusCode(404);
            }else{

                // var options = new JsonSerializerOptions { WriteIndented = true };
                // string status = JsonSerializer.Serialize(StatusCode(200));
                // string content = JsonSerializer.Serialize(_personService.Filter(sortBy, value));
                // var jsonString = String.Concat(status, content);

                // return new JsonResult(jsonString, options);

                return new JsonResult(_personService.Filter(sortBy, value));
            }

        }
    }
}
