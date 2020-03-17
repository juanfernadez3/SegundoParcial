using System;
using System.Collections.Generic;
using System.Text;
using SegundoParcial.Entidades;
using SegundoParcial.BLL;
using SegundoParcial.Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;


namespace SegundoParcial.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamadas)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Llamadas.Add(llamadas) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Llamadas llamadas)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"Delete from LlamadaDetalle where LlamadaId ={llamadas.LlamadaId}");
                foreach(var item in llamadas.Llamada)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(llamadas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Llamadas.Find(id);
                db.Entry(eliminar).State=EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Llamadas Buscar(int id)
        {
            Llamadas llamadas = new Llamadas();
            Contexto db = new Contexto();

            try
            {
                llamadas = db.Llamadas.Where(o => o.LlamadaId == id).
                    Include(l => l.Llamada).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return llamadas;
        }

        public static List<Llamadas>GetList(Expression<Func<Llamadas, bool>> llamadas)
        {
            List<Llamadas> lista = new List<Llamadas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Llamadas.Where(llamadas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
