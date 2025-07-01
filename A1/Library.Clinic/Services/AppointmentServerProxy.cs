 
using Library.Clinic.Models;

namespace Library.Clinic.Services;

public class AppointmentServerProxy
{
        private static object _lock = new object();
        private int lastKey
        {
            get
            {
                if (Appointments.Any())
                {
                    return Appointments.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
     

        private static AppointmentServerProxy? _instance;
        public static AppointmentServerProxy Current
        {
            get
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppointmentServerProxy();
                    }
                }
                return _instance;
            }
        }
             public List<AppointmentDTO> appointments;
     
    public List<AppointmentDTO> Appointments {get{
        return appointments;
    } 
    private set{
        if(appointments!=value){
            appointments=value;
        }
    }
    }
        public void AddOrUpdate(AppointmentDTO a)
        {
            var isAdd = false;
            if(a.Id <= 0)//add
            {
                a.Id = lastKey + 1;
                isAdd = true;
            }

            if(isAdd)//update
            {
                Appointments.Add(a);
            }else{
                //go in remove all and tehn delete the existing add a new 
            }

        }
           public void DeleteApp(int id) {
            var appToRemove = Appointments.FirstOrDefault(p => p.Id == id);

            if (appToRemove != null)
            {
                Appointments.Remove(appToRemove);
            }
        }
        
    }

