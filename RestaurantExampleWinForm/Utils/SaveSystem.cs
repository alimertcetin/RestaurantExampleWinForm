using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace XIV.SaveSystems
{
    public static class SaveSystem
    {
        public static void Save(object objectToSave, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                try
                {
                    bf.Serialize(fs, objectToSave);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static T Load<T>(string path) where T : class
        {
            if (!File.Exists(path))
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    return (T)bf.Deserialize(fs);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}