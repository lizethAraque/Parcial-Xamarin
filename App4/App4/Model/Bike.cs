using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public  class Bike
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public String imagen { get; set; }
    }
}
