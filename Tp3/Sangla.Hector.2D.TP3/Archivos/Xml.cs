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
