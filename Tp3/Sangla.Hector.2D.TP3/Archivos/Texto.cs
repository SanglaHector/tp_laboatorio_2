using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exepciones;
namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            try
            {
                sw.Write(datos);
            }
            catch(Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                sw.Close();
            }
            return true;
        }
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);
            try
            {
                datos = sr.ReadToEnd();

            }catch(Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                sr.Close();
            }
            return true; 
        }

    }
}
