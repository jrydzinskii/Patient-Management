using Api.Clinic.Database;
using Library.Clinic.DTO;
using Library.Clinic.Models;

namespace Api.Clinic.Enterprise
{
    public class PhysicianEC
    {
        public PhysicianEC() { }

       public IEnumerable<PhysicianDTO> Physicians
        {
            get
            { 
                return FakeDatabase.Physicians.Select(p => new PhysicianDTO(p));
            }
        }
        
        public IEnumerable<PhysicianDTO>? Search(string query)
        {
            return FakeDatabase.Physicians
                .Where(p => p.Name.ToUpper()
                    .Contains(query?.ToUpper() ?? string.Empty))
                .Select(p => new PhysicianDTO(p));
        }

        public PhysicianDTO? GetById(int id)
        {
            var physician = FakeDatabase
                .Physicians
                .FirstOrDefault(p => p.Physid == id);
            if(physician != null)
            {
                return new PhysicianDTO(physician);
            }

            return null;
        }

        public PhysicianDTO? Delete(int id)
        {
            var physiciantodelete = FakeDatabase.Physicians.FirstOrDefault(p => p.Physid == id);
            if (physiciantodelete != null)
            {
                FakeDatabase.Physicians.Remove(physiciantodelete);
                return new PhysicianDTO(physiciantodelete);
            }

            return null;
        }

        public Physician? AddOrUpdate(PhysicianDTO? physician)
        {
            if(physician == null)
            {
                return null;
            }
            return FakeDatabase.AddOrUpdatePhysician(new Physician(physician));
        }
    }
}