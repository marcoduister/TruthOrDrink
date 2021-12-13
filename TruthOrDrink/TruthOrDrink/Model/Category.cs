using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [Column("Userid")]
        [ForeignKey(typeof(User))]
        public int Userid { get; set; }

        [ManyToOne]
        public User User { get; set; }

        [OneToMany]
        public List<Question> QuestionList { get; set; }

        [OneToMany]
        public List<Game> GameList { get; set; }
    }
}
