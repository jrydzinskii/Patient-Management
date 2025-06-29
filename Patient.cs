using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1
{
    internal class Patient{
        //public string Name { get; set; }
        public int Id {get; set;}//unique set 
        private string? name;
        public string Name {
            get {
                return name ?? string.Empty;
            }
            set {
                name = value;
            }
        }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string race { get; set; }

        public string gender{ get; set;}

        public Patient() {
            Name = string.Empty;
            Address = string.Empty;
            Birthday= DateTime.MinValue;
            Race = string.Empty;
            Gender=string.Empty;

        }

    }

    internal class Physician{
        //public string Name { get; set; }
        public int Id {get; set;}
        private string? name;
        public string Name {
            get {
                return name ?? string.Empty;
            }
            set {
                name = value;
            }
        }
        public DateTime GradDate { get; set; }
        public string license { get; set; }
        public string special { get; set; }

        public Physician() {
            Name = string.Empty;
            GradDate= DateTime.MinValue;//,maybe maybe not
            License = string.Empty;
            Special= string.Empty;

        }

    }

    internal class Appointment(){
        private string? hour;//track military time
        private string? day;
      
        public DateTime appoint{ get;set; }
      

        public string NamePhys{get; set;}//get who has apponit
        public Appointment(){
            appoint= DateTime.MinValue;
        }
    }
}