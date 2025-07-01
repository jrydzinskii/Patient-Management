namespace Library.Clinic;

 public  class TreatmentDTO
    {
        public TreatmentDTO() { }
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