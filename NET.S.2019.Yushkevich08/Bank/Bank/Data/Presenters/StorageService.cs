using System.Collections.Generic;
using System.IO;
using Bank.Data.Models;

namespace Bank.Data.Presenters
{
     public class StorageService
    {
        /// <summary>Load File</summary>
        /// <param name="path">file path</param>
        /// <returns>List of accounts</returns>
        public static List<Account> LoadFromFile(string path)
        {
            List<Account> list = new List<Account>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                Account item;
                while (reader.PeekChar() != -1)
                {
                    item = new Account(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadInt32());
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>Write File</summary>
        /// <param name="path">file path</param>
        public static void SaveToFile(string path, List<Account> list)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account a in list)
                {
                    writer.Write(a.ID);
                    writer.Write(a.Name);
                    writer.Write(a.Surname);
                    writer.Write(a.Status.ToString());
                    writer.Write(a.Balance);
                    writer.Write(a.Bonuses);
                }
            }
        }
    }
}
