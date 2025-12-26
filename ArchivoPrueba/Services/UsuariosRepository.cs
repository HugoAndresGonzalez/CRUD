using ArchivoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchivoPrueba.Services
{
    public class UsuariosRepository
    {
        public PruebasContext context = new PruebasContext();
        public List<Usuarios> ConsultaTodos() 
        {
            List<Usuarios> List = new List<Usuarios>();
            try
            {
                List = context.Usuarios.Where(x => x.Estado == true |  x.Estado==false).ToList();
            }
            catch (Exception ex)
            {

            }
            
            return List;  
        }
        public Usuarios ObtenerDato(int Id)
        {
            Usuarios usuario = new Usuarios();
            try
            {
                usuario = context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo el usuario", ex);
            }
            return usuario;
        }

        public String AddUsuario(Usuarios model)
        {
            try
            {
                context.Usuarios.Add(model);
                context.SaveChangesAsync(); 
            }catch (Exception ex)
            {

            }
            return "";
        }

        public String DeleteUsuario(int id, Usuarios model)
        {
            try
            {
                Usuarios datos = ObtenerDato(id);
                context.Usuarios.Remove(datos);
                context.SaveChangesAsync(); 
            }catch (Exception ex)
            {

            }
            return "";
        }
        public  String EditUsuarios(int id,Usuarios model)
        {
            try
            {
                Usuarios datos = ObtenerDato(id);
                context.Usuarios.Attach(datos);

                if (datos.Nombres != model.Nombres)
                {
                    datos.Nombres = model.Nombres;
                }
                  
                datos.Apellidos= model.Apellidos;   
                datos.Estado= model.Estado;  
                context.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {
            }
            return "";
        }
    }
}