using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.DTO;

namespace Library.Clinic.Models
{
    public class Patient{
        //public string Name { get; set; }
        public override string ToString()
        {
           return Display;
        }
        public string Display{
            get{
                return $"[{Id} {Name}]"; //this is why you didnt need to bind patient like you did physician
            }
        }
    
        public  int Id {get; set;}//unique set 
        private string? name;
        public string Name {
            get {
                return name ?? string.Empty;
            }
            set {
                name = value;
            }
        }
      
        public DateOnly Birthday { get; set; }
        public string Address { get; set; }
        public string Race { get; set; }
        public string Gender{ get; set;}
        public string? Diagnosis{get;set;}
        public string? Prescript {get; set;}
  
        public string? Company{get;set;}
        public float Price{get;set;}

         public Treatment? Treatment { get; set; }

        public string abcd1{get;set;}
        public string abcd2{get;set;}
        public string abcd3{get;set;}
        public string abcd4{get;set;}
        public string abcd5{get;set;}
        public string abcd6{get;set;}
        public string abcd7{get;set;}
        public string abcd8{get;set;}
        public Patient() {
            Name = string.Empty;
            Address = string.Empty;
            Birthday= DateOnly.MinValue;
            Race = string.Empty;
            Gender=string.Empty;
            Prescript=string.Empty;
            Diagnosis=string.Empty;



        }
        public Patient(PatientDTO pat){
            Name = pat.Name ?? string.Empty;
            Address = pat.Address ?? string.Empty;
            Birthday= pat.Birthday;
            Race = pat.Race ??string.Empty;
            Gender=pat.Gender ??string.Empty;
            Prescript=pat.Prescript??string.Empty;
            Diagnosis=pat.Diagnosis??string.Empty;
        }
 

    }

    public class Physician{

        public int Physid{get;set;}
        private string? name;
        public string Name {
            get {
                return name ?? string.Empty;
            }
            set {
                name = value;
            }
        }
        public DateOnly GradDate { get; set; }
        public int License { get; set; }
        public string Special { get; set; }
        public string abcd1{get;set;}
        public string abcd2{get;set;}
        public string abcd3{get;set;}
        public string abcd4{get;set;}
        public string abcd5{get;set;}
        public string abcd6{get;set;}
        public string abcd7{get;set;}
        public string abcd8{get;set;}
        public Physician() {
            Name = string.Empty;
            GradDate= DateOnly.MinValue;//,maybe maybe not;
            License= int.MinValue;
            Special= string.Empty;

        }
           public Physician(PhysicianDTO phys){
            Name = phys.Name ?? string.Empty;
            GradDate=phys.GradDate;//,maybe maybe not;
            License= phys.License;
            Special= phys.Special ?? string.Empty;
     
        }

    }
    public  class Insurance
    {
        public Insurance() { }
        private string? company;
        public string Company {
            get {
                return company ?? string.Empty;
            }
            set {
                company = value;
            }
        }
        public int Id{get;set;}

        public float Price { get; set; }
       
    }

    public  class Treatment
    {
        public Treatment() { }
        public int Id{get;set;}
         private string? type;
        public string Type {
            get {
                return type ?? string.Empty;
            }
            set {
                type = value;
            }
        }
        public int Price { get; set; }
    }
}