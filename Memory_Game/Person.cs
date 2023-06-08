using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    public class Person
    {
        public string name;
        public int board_size;
        public int number_of_lives;
        public int showing_time;
        public int number_of_tiles;
        public Person(string name,int board_size,int number_of_lives,int showing_time,int number_of_tiles)
        {
            this.name = name;
            this.board_size = board_size;
            this.number_of_lives= number_of_lives;
            this.showing_time= showing_time;
            this.number_of_tiles= number_of_tiles;
        }

    }
}
