using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Players
    {
        private char _icon;
        private string _name;

        public char Icon { get {return _icon; } set { _icon = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public Players(char icon,string name)
        {
            Icon = icon;
            Name = name;
        }




    }
}
