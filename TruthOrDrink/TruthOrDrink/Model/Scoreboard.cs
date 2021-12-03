using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TruthOrDrink.Model
{
    [Table("Scoreboard")]
    public class Scoreboard
    {

        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PlayerName")]
        public string PlayerName { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Indexed]
        [Column("Player_Id")]
        public int Playerid { get; set; }
        [Indexed]
        [Column("Game_id")]
        public int Gameid { get; set; }
    }
}
