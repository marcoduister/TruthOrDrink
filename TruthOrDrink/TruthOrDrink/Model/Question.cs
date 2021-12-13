using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TruthOrDrink.Model
{
    [Table("Player")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Question")]
        public string QuestionItem { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Categoryid")]
        [ForeignKey(typeof(Category))]
        public int Categoryid { get; set; }

        [Column("Userid")]
        [ForeignKey(typeof(User))]
        public int Userid { get; set; }

        [ManyToOne]
        public Category Category { get; set; }

        [ManyToOne]
        public User User { get; set; }

    }
}
