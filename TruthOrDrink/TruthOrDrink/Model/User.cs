using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }

    }
}
