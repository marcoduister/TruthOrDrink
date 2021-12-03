using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

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

        [Indexed]
        [Column("Category_Id")]
        public int Categoryid { get; set; }

        [Indexed]
        [Column("Maker_id")]
        public int Userid { get; set; }



    }
}
