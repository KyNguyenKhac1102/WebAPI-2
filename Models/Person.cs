using System;

namespace WebAPI_2.Models{
    public class Person{
        public Guid Id {get; set;}
        public string FristName {get; set;}
        public string LastName {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string Gender {get; set;}
        public string BirthPlace {get; set;}

        public string FullName(){
            return $"{FristName} {LastName}";
        }
    }
}