﻿using Microsoft.VisualBasic.CompilerServices;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget1.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        //CreateConnection();

    }
}
