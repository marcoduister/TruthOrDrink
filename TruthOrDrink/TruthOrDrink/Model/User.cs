using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace TruthOrDrink.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("NickName")]
        public string NickName { get; set; }
        [Column("Password")]
        public string Password { get; set; }

        [OneToMany]
        public List<Question> QuestionList { get; set; }

        [OneToMany]
        public List<Category> CategoryList { get; set; }

        [OneToMany]
        public List<Game> GameList { get; set; }

    }
}
