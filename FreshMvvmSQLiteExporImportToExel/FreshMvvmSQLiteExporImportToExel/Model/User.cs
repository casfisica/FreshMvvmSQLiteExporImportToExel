using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FreshMvvmSQLiteExporImportToExel.Model
{
    public class User
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }

        [MaxLength (50)]
        public string UserName { get; set; }
        public string PassWD { get; set; }
        public int IsAdmin { get; set; }
        
    }
}
