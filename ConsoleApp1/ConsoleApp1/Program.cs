using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usando entity Framework
            using (TESTEntities1 contexto = new TESTEntities1())
            {
                // EF LINQ - Seleccionando la tupla con at1 = 1
                table1 t = (from t1 in contexto.table1
                            where t1.at1 == 1
                            select t1).FirstOrDefault();
                Console.WriteLine(t.at1.ToString() + " ----> " + t.at2);
                // EF LAMBDA - - Seleccionando la tupla con at1 = 2
                table1 t2 = contexto.table1
                .FirstOrDefault(aux => aux.at1 == 2);
                Console.WriteLine(t2.at1.ToString() + " ----> " + t2.at2);
                // SQL Native - Seleccionando la tupla con at1 = 3
                // Cuidado!!!​ La conexión no va hardcode aquí, la misma debe estar en el archivo de
                //configuración de la aplicación.
 using (SqlConnection con = new SqlConnection("data source = LAPTOP - RVJ7IF0A\\SQLEXPRESS; initial catalog = TEST; persist security info = True; user id = tisj; password = tisj; MultipleActiveResultSets = True; "))
            {
                    using (SqlCommand com = new SqlCommand("SELECT at1, at2 FROM Table1 WHERE at1  @param", con))
                    {
                        com.Parameters.Add(new SqlParameter("param",
                   System.Data.SqlDbType.Int)).Value = 3;
                    con.Open();
                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Console.WriteLine(dr.GetInt32(0).ToString() + " ----> " +
                           dr.GetString(1));
                        }
                    }
                }
            }
            // Esperamos una lectura antes que el programa termine.
            string entrada = Console.ReadLine();
        }


    }
}
}
