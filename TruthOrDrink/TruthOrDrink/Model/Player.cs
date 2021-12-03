using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

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
        public byte ProfileImage { get; set; }
        [Indexed]
        [Column("Game_Id")]
        public int Gameid { get; set; }

       



    }
}
