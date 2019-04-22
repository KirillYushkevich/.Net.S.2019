using System.Collections.Generic;
using System.IO;
using ELibrary.Data.Models;

namespace ELibrary.Data.Presenters
{
     public class StorageService
    {
        public static List<Book> LoadFromFile(string path)
        {
            List<Book> list = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                Book item;
                while (reader.PeekChar() != -1)
                {
                    item = new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                    list.Add(item);
                }
            }

            return list;
        }

        public static void SaveToFile(string path, List<Book> list)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in list)
                {
                    writer.Write(b.ISBN);
                    writer.Write(b.Author);
                    writer.Write(b.Title);
                    writer.Write(b.Publisher);
                    writer.Write(b.PublishYear);
                    writer.Write(b.PageAmount);
                    writer.Write(b.Price);
                }
            }
        }
    }
}
