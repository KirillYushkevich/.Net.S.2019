using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.IO;
using DAL.Interface;

namespace DAL.Repositories
{
    public class AccountBinaryRepository:IRepository
    {
        private string _path;
        public AccountBinaryRepository(string path)
        {
            path = _path;
        }

        public IEnumerable<AccountDTO> LoadFromFile()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            using (BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.OpenOrCreate)))
            {
                AccountDTO item;
                while (reader.PeekChar() != -1)
                {
                    item = new AccountDTO();
                    item.AccountNumber = reader.ReadInt32();
                    item.Balance = reader.ReadInt32();
                    item.Bonuses = reader.ReadInt32();
                    item.Owner = reader.ReadString();
                    AccountType temp;
                    Enum.TryParse(reader.ReadString(),true,out temp);
                    item.Type = temp;
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>Write File</summary>
        /// <param name="path">file path</param>
        public void SaveToFile(IEnumerable<AccountDTO> list)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.OpenOrCreate)))
            {
                foreach (AccountDTO a in list)
                {
                    writer.Write(a.AccountNumber.ToString());
                    writer.Write(a.Balance);
                    writer.Write(a.Bonuses);
                    writer.Write(a.Owner);
                    writer.Write(a.Type.ToString());
                }
            }
        }
    }
}
