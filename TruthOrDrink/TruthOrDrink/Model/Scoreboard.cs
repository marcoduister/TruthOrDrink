using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TruthOrDrink.Model
{
    [Table("Scoreboard")]
    public class Scoreboard
    {

        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PlayerName")]
        public string PlayerName { get { return player.Playername; } }
        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Playerid")]
        [ForeignKey(typeof(Player))]
        public int Playerid { get; set; }

        [Column("Gameid")]
        [ForeignKey(typeof(Game))]
        public int Gameid { get; set; }

        [ManyToOne]
        public Player player { get; set; }

        [OneToOne]
        public Game Game { get; set; }
    }
}
