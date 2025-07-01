using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.DTO
{
    public class PatientDTO
    {
        public override string ToString()
        {
            return Display;
        }

        //TODO: Remove this and put it on a ViewModel instead
        public string Display
        {
            get
            {
                return $"[{Id}] {Name}";
            }
        }
        public int Id { get; set; }
        public string? Name { get; set;}
        public DateOnly Birthday { get; set; }
        public string? Address { get; set; }
         public string? Race { get; set; }
        public string? Gender{ get; set;}
        public string? Diagnosis{get;set;}
        public string? Prescript {get; set;}
        public InsuranceDTO? Insurance { get; set; }
        public string? Company{get;set;}
        public float Price{get;set;}

     
        public PatientDTO(Patient p)
        {
            Id = p.Id;
            Name = p.Name;
            Birthday = p.Birthday;
            Address = p.Address;
            Diagnosis=p.Diagnosis;
            Gender=p.Gender;
            Race=p.Race;
            Prescript=p.Prescript;
        }
    }
       

   
}
