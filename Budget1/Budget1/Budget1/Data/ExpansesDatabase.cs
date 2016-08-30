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

                return dataBase.Get<Items>(id);                
                //return (from c in dataBase.Table<Items>() where (c.CategoryId==id) select c).ToList();
                //dataBase.Table<Items>().Where(c => c.Id==id).FirstOrDefault();
            }
        }

        public void SaveExpanse(Exapnses expanse)
        {
            lock (locker)
            {

                if (expanse.ID != 0)
                {

                    dataBase.Update(expanse);
                    //return expanse.ID;

                } else

                {
                     dataBase.Insert(expanse);
                    //return expanse.ID;

                }
            }
        }

        public void SaveItems(Items item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    dataBase.Update(item);
                }
                else
                {
                    dataBase.Insert(item);
                }
            }
        }

        public void SaveAll(Exapnses expanse, Items item)
        {
            expanse.Items = new List<Items> { item };
            dataBase.UpdateWithChildren(expanse); 
        }

        public IEnumerable<Exapnses> GetExpanses()
        {
            lock (locker)
            {
                //return (from c in dataBase.Table<Exapnses>() select c).ToList();

                return dataBase.GetAllWithChildren<Exapnses>();

            }
        }


        public Exapnses GetExpanse(int id)
        {
            lock (locker)
            {
                return dataBase.GetWithChildren<Exapnses>(id);
            }
        }

        public string GetCategory(int id)
        {
            var answer = (from c in dataBase.Table<Exapnses>() where (c.ID == id) select c.Category).ToList();
            return answer[0].ToString();
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
