

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.DTO;

namespace Library.Clinic.Models
{
    public  class Appointment
    {
        public Appointment() { }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
   
        public int PatientId { get; set; }
        public PatientDTO? Patient { get; set; }
        public PhysicianDTO? Physician { get; set; }
         public InsuranceDTO? Insurance { get; set; }
         public TreatmentDTO? Treatment { get; set; }
        public int PhysicianId{get;set;}
        public int InsuranceId{get;set;}
        public int TreatmentId{get;set;}
     
    }
}

