using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace TruthOrDrink.Model
{
    [Table("Player")]
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Playername")]
        public string Playername { get; set; }
        [Column("Score")]
        public int Score { get; set; }
        [Column("ProfileImage")]
        public byte[] ProfileImage { get; set; }

        [Column("Gameid")]
        [ForeignKey(typeof(Game))]
        public int Gameid { get; set; }

        [OneToOne]
        public Scoreboard Scoreboard { get; set; }

        [ManyToOne]
        public Game Game { get; set; }


    }
}
