using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    class Player
    {
        public Player()
        {

        }

        private int id;
        private string nickName;
        private int score;
        private byte profileImage;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public byte ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }
    }
}
