using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    class Scoreboard
    {
        Scoreboard()
        {

        }

        private int id;
        private string nickname;
        private DateTime date;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NickName
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}
