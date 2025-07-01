using Library.Clinic.Models;
namespace Library.Clinic;

public  class InsuranceDTO
    {
        public InsuranceDTO() { }
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