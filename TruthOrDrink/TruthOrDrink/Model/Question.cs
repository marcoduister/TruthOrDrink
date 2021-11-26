using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    class Question
    {
        public Question()
        {

        }

        private int id;
        private string _question;
        public virtual Category Category { get; set; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string _Question
        {
            get { return _question; }
            set { _question = value; }
        }
    }
}
