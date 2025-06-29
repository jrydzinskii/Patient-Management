using Library.Clinic.Models;

namespace Api.Clinic.Database
{
    static public class FakeDatabase
    {
        public static int LastKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        //private static FakeDatabase? _instance = new FakeDatabase();

        private static List<Patient> patients = new List<Patient>
        {
                  new Patient {Id = 1
                , Name = "Jordan", Company="Hello Help", Price=65
                
                },
                new Patient{
                    Id=2, Name= "Lilly", Company="Hello Help", Price=80
                }
        };
        public static List<Patient> Patients { 
            get
            {
                return patients;
            } 
        }
        public static Patient? AddOrUpdatePatient(Patient? patient)
        {
            if (patient == null)
            {
                return null;
            }

            bool isAdd = false;
            if (patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                Patients.Add(patient);
            }

            return patient;
        }

         public static int LastPhysKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.Physid).Max();
                }
                return 0;
            }
        }
        private static List<Physician> physicians = new List<Physician>
        {
                  new Physician {Physid = 1
                , Name = "Ryan", 
                
                },
                new Physician{
                    Physid=2, Name= "Sally", 
        }
        
        };
        public static List<Physician> Physicians { 
            get
            {
                return physicians;
            } 
        }
        public static Physician? AddOrUpdatePhysician(Physician? physician)
        {
            if (physician == null)
            {
                return null;
            }

            bool isAdd = false;
            if (physician.Physid <= 0)
            {
                physician.Physid = LastPhysKey + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                Physicians.Add(physician);
            }

            return physician;
        }
    }
}