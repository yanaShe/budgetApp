using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingBudgetList.Models;

namespace TestingBudgetList.Data
{
    public interface ISerialization
    {
        void SerializeObject(List<Exapnses> expanse);
        List<Exapnses> Deserialize();

        //SQLiteConnection GetConnection();
    }
}
