using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static  class GuardarString
    {
        /// <summary>
        /// Metodo de extencion para guardar un archivo
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = String.Format("{0}\\{1}", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), archivo);
            try
            {
                using (StreamWriter st = new StreamWriter(path, true))
                    st.WriteLine(texto);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
