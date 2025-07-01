using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.DTO
{
    public class PhysicianDTO
    {
        public override string ToString()
        {
            return Display;
        }

        //TODO: Remove this and put it on a ViewModel instead
        public string Display
        {
            get
            {
                return $"[{Physid}] {Name}";
            }
        }
        public int Physid { get; set; }
        public string? Name { get; set;}
      public DateOnly GradDate { get; set; }
        public int License { get; set; }
        public string? Special { get; set; }       

        public PhysicianDTO() { }
        public PhysicianDTO(Physician p)
        {
            Physid = p.Physid;
            Name = p.Name;
            GradDate = p.GradDate;
            License=p.License;
            Special=p.Special;
        }
    }
}