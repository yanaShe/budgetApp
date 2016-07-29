using Budget1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Budget1.Data
{
    public class ExpansesDatabase
    {
        private SQLiteConnection dataBase;
        static object locker = new object();

        public ExpansesDatabase()
        {
            dataBase = DependencyService.Get<ISQLite>().GetConnection();
            dataBase.CreateTable<Exapnses>();
        }

        public int SaveExpanse(Exapnses expanse)
        {
            lock (locker)
            {
                if (expanse.ID != 0)
                {
                    dataBase.Update(expanse);
                    return expanse.ID;
                }
                else
                {
                    return dataBase.Insert(expanse);
                }
            }
        }

        public IEnumerable<Exapnses> GetExpanses()
        {
            lock (locker)
            {
                return (from c in dataBase.Table<Exapnses>() select c).ToList();
            }
        }

        public Exapnses GetExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.Table<Exapnses>().Where(c => c.ID == id).FirstOrDefault();
            }
        }

        public int DeleteExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.Delete<Exapnses>(id);
            }
        }

    }
}
