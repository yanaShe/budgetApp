using Budget1.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLiteNetExtensions.Extensions;


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

        internal object GetItem(int id)
        {
            lock (locker)
            {
                return dataBase.Table<Items>().Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public int SaveExpanse(Exapnses expanse)
        {
            lock (locker)
            {
                if (expanse.ID != 0)
                {
                    //dataBase.Update(expanse);
                    dataBase.UpdateWithChildren(expanse);
                    return expanse.ID;

                    
                } else
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

        //public IEnumerable<Exapnses> GetItems()
        //{
        //    lock (locker)
        //    {
        //        var data = from c in dataBase.Table<Exapnses>()
        //                   group c by c.Category;

        //        return (IEnumerable<Exapnses>)data.ToList();

        //    }
        //}
        public Exapnses GetExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.Table<Exapnses>().Where(c => c.ID == id).FirstOrDefault();
            }
        }

        public IEnumerable<Exapnses> GroupItemByCategory()
        {
            lock (locker)
            {
                //return dataBase.Table<Exapnses>().Where(c => c.Category == expenses.Category).ToList();
                var query = (from c in dataBase.Table<Exapnses>()
                             group c by c.Category into results
                             orderby results.Key
                             select results).ToList();

                return (IEnumerable<Exapnses>)query;
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
