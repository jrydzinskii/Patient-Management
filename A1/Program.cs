using System;
using System.Data;
using System.Data.Common;

using Library.Clinic.Services;
using Library.Clinic.Models;


internal class Program
{
static void Main(string[] args){ 
    bool cont=true;
    do{
    
        Console.WriteLine("Select an option: ");
        Console.WriteLine("A. Add a Patient");
        Console.WriteLine("B. Add a Physician");
        Console.WriteLine("C. Create an Apointment");
        Console.WriteLine("D. Track Medical Notes");
        Console.WriteLine("Q.Quit program");


        string input = Console.ReadLine() ?? string.Empty;

        List<Patient> Patients = new List<Patient>();
        List<Physician> Physicians=new List<Physician>();//create lists
        List<Appointment> Appointments= new List<Appointment>();

        if(char.TryParse(input, out char choice))
        {
            switch(choice) {
                case 'a':
                case 'A':
                    Console.WriteLine("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter Birthday mm/dd/yyyy:");
                    var birth=Console.ReadLine();
                    DateOnly day;
                    DateOnly.TryParse(birth, out day);
                    Console.WriteLine("Enter address: ");
                    var address= Console.ReadLine();
                    Console.WriteLine("Enter Race: ");
                    var race= Console.ReadLine();
                    Console.WriteLine("Enter Gender: ");
                    var gender=Console.ReadLine();
                    var newPatient = new Patient { Name = name ?? string.Empty,Birthday= day,Address= address
                     ?? string.Empty, Race=race ?? string.Empty, Gender=gender?? string.Empty};
                    //PatientServerProxy.AddPatient(newPatient);
                   Console.WriteLine("Patient created");
                  

                    break;
                case 'b':
                case 'B':
                    Console.WriteLine("Enter Name: ");
                     name= Console.ReadLine();
                    Console.WriteLine("Enter their Graduation date mm/dd/yyyy: ");
                    var date=Console.ReadLine();
                    DateOnly gradd;
                    DateOnly.TryParse(date, out gradd);
                    Console.WriteLine("Enter License: ");
                    var linum =Console.ReadLine();
                    int licnum;
                    int.TryParse(linum, out licnum);

                    Console.WriteLine("Enter Specialties: ");
                    var special= Console.ReadLine();

                    var newphysician=new Physician {Name =name ??string.Empty,GradDate=gradd,License=licnum , Special=special ?? string.Empty};
                    
                    //PatientServerProxy.AddPhysician(newphysician);
                    Console.WriteLine("Physician created");
                    break;


                 case 'c':
                 case 'C':
                    Console.WriteLine("Enter Id of the Patient:");
                    int appointee=int.Parse(Console.ReadLine()??"-1");
                           
                        //PatientServerProxy.Appointmentfor(appointee); 
                        
                    
                    break;
                case 'd':
                case'D':
                    Console.WriteLine("Enter Id of Patient to add records to:");
                    int selectpatient=int.Parse(Console.ReadLine()??"-1");
             
               
                   //PatientServerProxy.AddMed(selectpatient);

                   
                    break;
               case 'q':
                case 'Q':
                    cont=false;
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        } else 
        {
            Console.WriteLine($"{choice} is not a char");
        }

     
       
    } while(cont);
    
        Console.WriteLine("Patients:");
        //PatientServerProxy.Patients.ForEach(x=>Console.WriteLine($"{x.Id}. {x.Name}, {x.Birthday},{x.Address},{x.Race},{x.Gender}, {x.Prescript},{x.Diagnosis}"));
        Console.WriteLine("Physicians:");
        //PatientServerProxy.Physicians.ForEach(x=>Console.WriteLine($"{x.Physid}. {x.Name}, {x.GradDate},{x.License},{x.Special}"));
        Console.WriteLine("Appointments:");
        //PatientServerProxy.Appointments.ForEach(x=>Console.WriteLine($"Dr.{x.NamePhys} has an appointment at {x.Appoint}"));
        
        
        
}
}
