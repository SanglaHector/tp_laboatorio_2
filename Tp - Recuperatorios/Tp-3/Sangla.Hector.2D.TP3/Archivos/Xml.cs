using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Exepciones;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Guarda un formato T en un archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8);
            bool retorno = false;
            try
            {
                serializer.Serialize(writer, datos);
                retorno = true;
            }catch(Exception e)
            {
                throw new ArchivosException(); 
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
        /// <summary>
        /// Lee un archivo xml y devuelve su contenido  en un formato T
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(archivo);
            try
            {
                datos = (T)serializer.Deserialize(reader);
                retorno = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException();
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
