using Budget1.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;

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
            dataBase.CreateTable<Items>();
            
    }

        public Items GetItem(int id)
        {
            lock (locker)
            {

                return dataBase.GetWithChildren<Items>(id);
                //dataBase.Table<Items>().Where(c => c.Id==id).FirstOrDefault();
            }
        }

        public void SaveExpanse(Exapnses expanse)
        {
            lock (locker)
            {

                if (expanse.ID != 0)
                {

                    dataBase.UpdateWithChildren(expanse);
                    //return expanse.ID;

                } else

                {
                     dataBase.InsertWithChildren(expanse);
                    //return expanse.ID;

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

        public int SaveItems(Items item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    dataBase.Update(item);
                    return item.Id;
                }
                else
                {
                    return dataBase.Insert(item);
                }
            }
        }

        public Exapnses GetExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.GetWithChildren<Exapnses>(id);
            }
        }
        
        public int DeleteExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.Delete<Exapnses>(id);
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return dataBase.Delete<Items>(id);
            }
        }

    }
}
