using System.Xml;

namespace AdaptiveRPG.Systems.Util
{
    /// <summary>
    /// This class is intended to enforce a consitent design pattern for how loading XML
    /// files to define Adpative RPG System's logic should work
    /// </summary>
    /// <typeparam name="SerializableClass"></typeparam>
    public class SystemLoader<SerializableClass> where SerializableClass : new()
    {
        private System.Xml.Serialization.XmlSerializer xml;

        public SystemLoader() {
            // Usefule article on using the serializer class
            // https://code-maze.com/csharp-xml-serialization/#:~:text=For%20serializing%20objects%20to%20XML%20in%20C%23%2C%20we,of%20a%20simple%20C%23%20class%3A%20public%20class%20Patient
            xml = new System.Xml.Serialization.XmlSerializer((typeof(SerializableClass)));
        }

        public virtual SerializableClass? Load(string path)
        {
            XmlReader reader = XmlReader.Create(path);
            SerializableClass? loaded = (SerializableClass?) xml.Deserialize(reader);
            reader.Close();

            return loaded;
        }

        public virtual void Write(string path, SerializableClass instance)
        {
            StreamWriter writer = new StreamWriter(path);
            using (writer)
            {
                xml.Serialize(writer, instance);
            }
        }

    }
}
