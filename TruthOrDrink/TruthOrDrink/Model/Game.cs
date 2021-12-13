using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

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

        [Column("Userid")]
        [ForeignKey(typeof(User))]
        public int Userid { get; set; }

        [Column("Categoryid")]
        [ForeignKey(typeof(Category))]
        public int Categoryid { get; set; }

        [ManyToOne]
        public User User { get; set; }

        [ManyToOne]
        public Category Category { get; set; }

        [OneToOne]
        public Scoreboard Scoreboard { get; set; }

        [OneToMany]
        public List<Player> PlayerList { get; set; }

    }
}
