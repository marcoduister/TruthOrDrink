using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace TruthOrDrink.Model
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }

        [Indexed]
        [Column("Maker_Id")]
        public int Userid { get; set; }

    }
}
