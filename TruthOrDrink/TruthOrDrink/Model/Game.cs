using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TruthOrDrink.Model
{
    [Table("Game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }

        [Indexed]
        [Column("Maker_id")]
        public int Userid { get; set; }
        [Indexed]
        [Column("Category_id")]
        public int Categoryid { get; set; }
    }
}
