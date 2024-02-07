using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BL
{
    public class Emisor
    {
        public static int Add(ML.Emisor emisor)
        {
            try
            {
                using (DL.MasteridiEntities context = new DL.MasteridiEntities())
                {
                    emisor.IdEmisor = context.Database.SqlQuery<int>(
                        "EXEC EmisorAdd @RFC, @FechaInicioOperacion, @Capital",
                        new SqlParameter("@RFC", emisor.RFC),
                        new SqlParameter("@FechaInicioOperacion", emisor.FechaInicioOperacion),
                        new SqlParameter("@Capital", emisor.Capital)
                    ).FirstOrDefault();

                    return emisor.IdEmisor;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string Update(ML.Emisor emisor)
        {
            try
            {
                using (DL.MasteridiEntities context = new DL.MasteridiEntities())
                {
                    var query = context.EmisorUpdate(
                        emisor.IdEmisor,
                        emisor.RFC,
                        emisor.FechaInicioOperacion,
                        emisor.Capital
                        );

                    if (query > 0)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false"; ;
            }
        }
        public static ML.Emisor GetById(int IdEmisor)
        {
            ML.Emisor result = null;
            try
            {
                using (DL.MasteridiEntities context = new DL.MasteridiEntities())
                {
                    var query = context.EmisorGetById(IdEmisor).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Emisor emisor = new ML.Emisor();
                        emisor.IdEmisor = query.IdEmisor;
                        emisor.RFC = query.RFC;
                        emisor.FechaInicioOperacion = query.FechaInicioOperacion.Value;
                        emisor.Capital = query.Capital.Value;

                        result = emisor;
                    }
                }
            }
            catch
            {
                // Manejo de excepciones
            }
            return result;
        }
        public static bool Delete(int IdEmisor)
        {
            try
            {
                using (DL.MasteridiEntities context = new DL.MasteridiEntities())
                {
                    var registro = context.EmisorDelete(IdEmisor);
                    if (registro > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static ML.Emisor GetAll()
        {
            ML.Emisor emisorobj = new ML.Emisor();
            emisorobj.Emisores = new List<ML.Emisor>();
            try
            {
                using (DL.MasteridiEntities context = new DL.MasteridiEntities())
                {
                    var query = context.EmisorGetAll();
                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Emisor emisor = new ML.Emisor();
                            emisor.IdEmisor = registro.IdEmisor;
                            emisor.RFC = registro.RFC;
                            emisor.FechaInicioOperacion = registro.FechaInicioOperacion.Value;
                            emisor.Capital = registro.Capital.Value;
                            emisorobj.Emisores.Add(emisor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emisorobj;
        }
    }
}