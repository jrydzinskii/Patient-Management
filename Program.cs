using System;
using A1;


internal class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Select an option: ");
        Console.WriteLine("A. Add a Patient");
        Console.WriteLine("B. Add a Physician");
        Console.WriteLine("C. Create an Apointment");
        Console.WriteLine("D. Access Patient Records");


        string input = Console.ReadLine() ?? string.Empty;

        List<Patient> patients = new List<Patient>();
        List<Physician> physicians=new List<Physician>();//create lists

        if(char.TryParse(input, out char choice))
        {
            switch(choice) {
                case 'a':
                case 'A':
                    Console.WriteLine("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter address: ");
                    var address= Console.ReadLine();
                    Console.WriteLine("Enter Race: ");
                    var race= Console.ReadLine();
                    Console.WriteLine("Enter Gender: ");
                    var gender=Console.ReadLine();
                    var newPatient = new Patient { Name = name ?? string.Empty, Address= address, Race=race, Gender=gender};
                    PatientServiceProxy.AddPatient(newPatient);
                   
                    break;
                case 'b':
                case 'B':
                    Console.WriteLine("Enter Name: ");
                    var name= Console.ReadLine();
                    Console.WriteLine("Enter their Graduation date: ");
                    Console.WriteLine("Enter License: ");
                    var license =Console.ReadLine ();
                    Console.WriteLine("Enter Specialties: ");
                    var special= Console.ReadLine();

                    var newphysician=new Physician {name =name ??string.Empty,GradDate=,License=license, Special=special };
                    
                    PatientServiceProxy.AddPhysician(newphysician);
                    break;


                 case 'c':
                 case'C':
                    if (time<8 ||time>17){//military hours
                        Console.WriteLine("The office is closed between these hours. Choose another time");
                     }   
                    if(day=='Saturday' ||day=='Sunday'){
                        Console.WriteLine("The office is not open on this day. Choose another day");
                    }
                    break;
               /* case 'd':
                case 'D':
                    PatientServiceProxy.Patients.ForEach(x => Console.WriteLine($"{++counter}. {x.Name}"));
                    int selectedPatient = int.Parse(Console.ReadLine() ?? "-1");
                    PatientServiceProxy.DeletePatient(selectedPatient);
                    break;*/
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        } else 
        {
            Console.WriteLine($"{choice} is not a char");
        }

        foreach(var patient in patients)
        {
            Console.WriteLine($"{patient}");
        }
        foreach(var physician in physicians)
        {
            Console.WriteLine($"{physician}");
        }
        //patients.ForEach(Console.WriteLine)  easier list print
        //patients.Where(x => x.Name.Constains("John")).ToList().ForEach(Console.WriteLine)  filter list and print
    }
}