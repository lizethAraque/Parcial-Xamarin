using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    class Bike
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
