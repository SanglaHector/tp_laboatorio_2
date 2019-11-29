using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static  class GuardaString
    {
        public static bool Guardar(this string texto, string nombreArchivo)
        {
            string path = String.Format("{0}\\{1}", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), nombreArchivo);
            bool retorno = false;
            StreamWriter writer = new StreamWriter(path, true);
            try
            {
                writer.Write(texto);
                retorno = true;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
    }
}
