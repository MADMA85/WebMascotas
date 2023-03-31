using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace WebMascotas.Models
{
    public class CRUD
    {
        private SqlConnection con;
        private string connString = "";

        private void GetConnectionString()
        {
            var builder = WebApplication.CreateBuilder();
            connString = builder.Configuration.GetConnectionString("DefaultConnection");
        }

        //**************** ADD NEW MACOTA *********************
        public bool AddMascota(Mascota mascota)
        {
            GetConnectionString();
            SqlConnection con = new SqlConnection(connString); 
            SqlCommand cmd = new SqlCommand("CRUDMascota", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@FechaRegistr", mascota.FechaRegistr);
            cmd.Parameters.AddWithValue("@Pedigri", mascota.Pedigri);
            cmd.Parameters.AddWithValue("@FechaNacimiento", mascota.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Raza", (int?)mascota.Raza );
            cmd.Parameters.AddWithValue("@EmailResponsable", mascota.EmailResponsable);
            cmd.Parameters.AddWithValue("@StatementType", "INSERT");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW MASCOTAS  ********************
        public List<Mascota> GetMascota()
        {
            List<Mascota> mascotalist = new List<Mascota>();

            GetConnectionString();

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "CRUDMascota";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", "");
                    cmd.Parameters.AddWithValue("@FechaRegistr", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Pedigri", "");
                    cmd.Parameters.AddWithValue("@FechaNacimiento", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Raza", 0);
                    cmd.Parameters.AddWithValue("@EmailResponsable", "");
                    cmd.Parameters.AddWithValue("@StatementType", "SELECT");

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                   
                    }
                }
            }

            string? nombre;

            foreach (DataRow dr in dt.Rows)
            {
                var s =dr.Field<string?>("Raza");
                var category = (Razas) Convert.ToInt16(s);

                mascotalist.Add(
                    new Mascota
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = Convert.ToString(dr["Nombre"]),
                        FechaRegistr = Convert.ToDateTime(dr["FechaRegistr"]),
                        Pedigri = Convert.ToBoolean(dr["Pedigri"]),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Raza = category,
                        EmailResponsable = Convert.ToString(dr["EmailResponsable"])
                    });
            }
            return mascotalist;
        }
    }
}
