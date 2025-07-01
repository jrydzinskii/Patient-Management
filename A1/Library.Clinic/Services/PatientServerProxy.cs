
using Library.Clinic.DTO;
using Library.Clinic.Models;
using Newtonsoft.Json;
using PP.Library.Util;

namespace Library.Clinic.Services;
public  class PatientServerProxy
{
    
        private static object _lock = new object();
        public static PatientServerProxy Current
        {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new PatientServerProxy();
                    }
                }
                return instance;
            }
        }
           private static PatientServerProxy? instance;
    public int LastKey
    {
        get{
            if(Patients.Any()){
                return Patients.Select(x => x.Id).Max();
            } 
            return 0;
                
            }
        }
  
  private PatientServerProxy(){//causes code to break down

   /*var patientsData= new WebRequestHandler().Get("/Patient").Result;
     Patients= JsonConvert.DeserializeObject<List<PatientDTO>>(patientsData) ?? new List<PatientDTO>(); //These cause the code to break wont let me back into patient or physician

    var physiciansData= new WebRequestHandler().Get("/Physicians").Result;//could be from the result
      Physicians= JsonConvert.DeserializeObject<List<PhysicianDTO>>(physiciansData) ?? new List<PhysicianDTO>();
    
    var treatmentsData= new WebRequestHandler().Get("/Treatments").Result;//could be from the result
      Treatments= JsonConvert.DeserializeObject<List<TreatmentDTO>>(treatmentsData) ?? new List<TreatmentDTO>();
   */   
    Patients=new List<Patient> 
    
    {
                new Patient {Id = 1
                , Name = "Jordan", Company="Hello Help", Price=65
                
                },
                new Patient{
                    Id=2, Name= "Lilly", Company="Hello Help", Price=80
                }
            };
            Physicians = new List<Physician> {
                new Physician {Physid = 1
                , Name = "Parker"
                },
                new Physician{
                    Physid=2, Name= "Landon"
                }
            };
             Treatments = new List<Treatment> {
                new Treatment {Id = 1
                , Type = "Broken Bone", Price = 780
                },
                new Treatment {Id = 2
                , Type = "C-Section", Price = 1020
                },
                new Treatment {Id = 3
                , Type = "Heart Surgery", Price = 1200
                },new Treatment {Id = 4
                , Type = "Check-in", Price = 80
                },
                new Treatment {Id = 5
                , Type = "Kidney Transplant", Price = 2040
                },
                new Treatment {Id = 6
                , Type = "Brain Surgery", Price = 1280
                },
                new Treatment {Id = 7
                , Type = "Blood transfusion", Price = 680
                },
                new Treatment {Id = 8
                , Type = "Tonsil Removal", Price = 1020
                },
                new Treatment {Id = 9
                , Type = "Colonoscopy", Price = 430
                },
                new Treatment {Id = 10
                , Type = "Hip Replacement", Price = 1120
                },
             };
  }
     public int LastPhy{
         get{
            if(Physicians.Any()){
                 return Physicians.Select(x => x.Physid ).Max();
            } 
             return 0;
        }
    }
    public List<Patient> patients;
     
    public List<Patient> Patients {get{
        return patients;
    } 
    private set{
        if(patients!=value){
            patients=value;
        }
    }
    }
   public async Task<List<Patient>> Search(string query) {

            var patientsPayload = await new WebRequestHandler()
                .Post("/Patient/Search", new Query(query));

            Patients = JsonConvert.DeserializeObject<List<Patient>>(patientsPayload)
                ?? new List<Patient>();

            return Patients;
        }
   /* public void AddorUpdatePatient(PatientDTO patient) {
        bool isAdd=false;
        if(patient.Id <= 0) {
            patient.Id = LastKey + 1;
            isAdd=true;
        }

        if(isAdd==true){
            Patients.Add(patient);
        }
        
    }*/
     public async Task<Patient?> AddOrUpdatePatient(Patient patient)
        {
            var payload = await new WebRequestHandler().Post("/patient", patient);
            var newPatient = JsonConvert.DeserializeObject<Patient>(payload);
            if(newPatient != null && newPatient.Id > 0 && patient.Id == 0)
            {
                //new patient to be added to the list
                Patients.Add(newPatient);
            } else if(newPatient != null && patient != null && patient.Id > 0 && patient.Id == newPatient.Id)
            {
                //edit, exchange the object in the list
                var currentPatient = Patients.FirstOrDefault(p => p.Id == newPatient.Id);
                var index = Patients.Count;
                if (currentPatient != null)
                {
                    index = Patients.IndexOf(currentPatient);
                    Patients.RemoveAt(index);
                }
                Patients.Insert(index, newPatient);
            }

            return newPatient;
        }
     public List<Physician> physicians;
     
    public List<Physician> Physicians {get{
        return physicians;
    } 
    private set{
        if(physicians!=value){
            physicians=value;
        }
    }
    }
       public async Task<List<Physician>> Searches(string query) {

            var physiciansPayload = await new WebRequestHandler()
                .Post("/Physician/Search", new Query(query));

            Physicians = JsonConvert.DeserializeObject<List<Physician>>(physiciansPayload)
                ?? new List<Physician>();

            return Physicians;
        }

     public async Task<Physician?> AddOrUpdatePhysician(Physician physician)
        {
            var payload = await new WebRequestHandler().Post("/physician", physician);
            var newPhysician = JsonConvert.DeserializeObject<Physician>(payload);
            if(newPhysician != null && newPhysician.Physid > 0 && physician.Physid == 0)
            {
 
                Physicians.Add(newPhysician);
            } else if(newPhysician != null && physician != null && physician.Physid > 0 && physician.Physid == newPhysician.Physid)
            {
                var currentPatient = Physicians.FirstOrDefault(p => p.Physid == newPhysician.Physid);
                var index = Physicians.Count;
                if (currentPatient != null)
                {
                    index = Physicians.IndexOf(currentPatient);
                    Physicians.RemoveAt(index);
                }
                Physicians.Insert(index, newPhysician);
            }

            return newPhysician;
        }
      /* public void AddorUpdatePatient(PatientDTO patient) {
        bool isAdd=false;
        if(patient.Id <= 0) {
            patient.Id = LastKey + 1;
            isAdd=true;
        }

        if(isAdd==true){
            Patients.Add(patient);
        }
        
    }*/
    /*public List<Physician> Physicians {get; private set;} = new List<Physician>();
     public void AddorUpdatePhysician(PhysicianDTO physician) {
           bool isAdd=false;
        if(physician.Physid <= 0) {
            physician.Physid = LastPhy + 1;
            isAdd=true;
        }

        if(isAdd){
            Physicians.Add(physician);
        }else{
            PhysicianDTO? old = Physicians.FirstOrDefault(p => p.Physid == physician.Physid);
            if(old != null){
                Physicians.Remove(old);
            }
            Physicians.Add(physician);
        }
    }

    public void DeletePatient(int id) {
            var patientToRemove = Patients.FirstOrDefault(p => p.Id == id);

            if (patientToRemove != null)
            {
                Patients.Remove(patientToRemove);
            }
        }
        */
         public async void DeletePatient(int id) {
            var patientToRemove = Patients.FirstOrDefault(p => p.Id == id);

            if (patientToRemove != null)
            {
                Patients.Remove(patientToRemove);

                await new WebRequestHandler().Delete($"/Patient/{id}");
            }
        }
             
    public async void DeletePhysician(int id) {
            var physicianToRemove = Physicians.FirstOrDefault(p => p.Physid == id);

            if (physicianToRemove != null)
            {
                Physicians.Remove(physicianToRemove);
                 await new WebRequestHandler().Delete($"/Physician/{id}");
            }
           
        }
  public List<Insurance> insurances;
     
    public List<Insurance> Insurances {get{
        return insurances;
    } 
    private set{
        if(insurances!=value){
            insurances=value;
        }
    }
    }
      public List<Treatment> treatments;
     
    public List<Treatment> Treatments {get{
        return treatments;
    } 
    private set{
        if(treatments!=value){
            treatments=value;
        }
    }
    }
}
 
