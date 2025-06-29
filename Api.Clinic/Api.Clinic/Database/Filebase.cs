using Library.Clinic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ToDoApplication.Persistence
{
    public class Filebase
    {
        private string _root;
        private string _patientRoot;
        private Filebase _instance;
         private string _physicianRoot;

        public Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"/user/jrydzins/";
            _patientRoot = $"{_root}\\Patients";
            _physicianRoot = $"{_root}\\Physicians";
        }

        public int LastKey
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

        public Patient AddOrUpdate(Patient patient)
        {
            //set up a new Id if one doesn't already exist
            if(patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
            }

            //go to the right place
            string path = $"{_patientRoot}\\{patient.Id}.json";
            

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(patient));

            //return the item, which now has an id
            return patient;
        }
        
        public List<Patient> Patients
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var _patients = new List<Patient>();
                foreach(var patientFile in root.GetFiles())
                {
                    var patient = JsonConvert
                        .DeserializeObject<Patient>
                        (File.ReadAllText(patientFile.FullName));
                    if(patient != null)
                    {
                        _patients.Add(patient);
                    }

                }
                return _patients;
            }
        }


        public bool Delete(string type, string id)
        {
            string path = $"{_patientRoot}\\{type}\\{id}.json";
        
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
                return true;
            }
            return false;//if doesnt exists
        }

        public Physician AddOrUpdate(Physician physician)
        {
            //set up a new Id if one doesn't already exist
            if(physician.Physid <= 0)
            {
                physician.Physid = LastKey + 1;
            }

            //go to the right place
            string path = $"{_physicianRoot}\\{physician.Physid}.json";
            

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(physician));

            //return the item, which now has an id
            return physician;
        }
        
        public List<Physician> Physicians
        {
            get
            {
                var root = new DirectoryInfo(_physicianRoot);
                var _physicians = new List<Physician>();
                foreach(var physicianFile in root.GetFiles())
                {
                    var physician = JsonConvert
                        .DeserializeObject<Physician>
                        (File.ReadAllText(physicianFile.FullName));
                    if(physician != null)
                    {
                        _physicians.Add(physician);
                    }

                }
                return _physicians;
            }
        }
        public bool Deletes(string type, string id)
        {
            string path = $"{_physicianRoot}\\{type}\\{id}.json";
        
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
                return true;
            }
            return false;//if doesnt exists
        }

    }


   
}