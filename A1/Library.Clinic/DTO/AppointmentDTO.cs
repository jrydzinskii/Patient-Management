using Library.Clinic.DTO;
namespace Library.Clinic;

 public  class AppointmentDTO
    {
        public AppointmentDTO() { }

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


