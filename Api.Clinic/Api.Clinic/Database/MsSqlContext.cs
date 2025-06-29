using Library.Clinic.Models;
using  Microsoft.Data.SqlClient;

using Library.Clinic.DTO;

namespace Api.Clinic.Database
{
    public class MsSqlContext
    {
        private string connectionString = "Server=CMILLS;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True";

        public MsSqlContext() { }

        public IEnumerable<Patient> GetPatients()
        {
            var returnVal = new List<Patient>();
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "select * from Patient";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = str;

                    try
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var newApp = new Patient
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            };

                            returnVal.Add(newApp);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }
   public IEnumerable<Physician> GetPhysicians()
        {
            var returnVal = new List<Physician>();
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "select * from Physician";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = str;

                    try
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var newApp = new Physician
                            {
                                Physid = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            };

                            returnVal.Add(newApp);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }
        public List<Appointment> GetAppointments()
        {
            var returnVal = new List<Appointment>();
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "select * from Appointments";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = str;

                    try { 
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            var newApp = new Appointment
                            {
                                Id = (int)reader["Id"]
                                , PatientId = (int)reader["PatientId"]
                                , StartTime = DateTime.Parse(reader["StartTime"].ToString() ?? "1901-01-01")
                               
                            };

                            returnVal.Add(newApp);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }

        public void DeletePhysician(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Physicians.[Delete]";
                using (var cmd = new SqlCommand(str, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var param = new SqlParameter("@physicianId", id);
                    cmd.Parameters.Add(param);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void UpdatePatient(Physician phys)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Physicians.[Update]";
                using (var cmd = new SqlCommand(str, conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@physicianId", phys.Physid));
                    cmd.Parameters.Add(new SqlParameter("@name", phys.Name));
                    cmd.Parameters.Add(new SqlParameter("@date", phys.GradDate));
                    cmd.Parameters.Add(new SqlParameter("@licensenumber", phys.License));
                    cmd.Parameters.Add(new SqlParameter("@special", phys.Special));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public Physician CreatePhysician(Physician phys)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Physicians.[Create]";
                using (var cmd = new SqlCommand(str, conn))
                {
                   /* declare @id int
                    exec Physicians.[Create] 
                    @name = 'John Lennon',
                    @date = '2002-03-01'
                    ,@licensenumber = 101290,
                    @special = 'Cardiologist'
                    @physicianId = @id output
                    select @id;*/

                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@name", phys.Name));
                    cmd.Parameters.Add(new SqlParameter("@date", phys.GradDate));
                    cmd.Parameters.Add(new SqlParameter("@licensenumber", phys.License));
                    cmd.Parameters.Add(new SqlParameter("@special", phys.Special));
                    var param = new SqlParameter("@physicianId", phys.Physid);
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    phys.Physid = (int)param.Value;
                    conn.Close();
                }

                return phys;
            }
        }

    }
}