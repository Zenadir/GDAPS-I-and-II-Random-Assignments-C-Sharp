using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_HW_3_Actual_Final
{
    public class Player : GameObject
    {

        public int TotalScore { get; set; }
        //Score to be displayed at the end of the game. 
        public int LevelScore { get; set; }
        //Will be displayed at the end of the current level. 
        public Player(int x, int y, int width, int height) : base(x, y, width, height)
        {
            
        }

        
    }
}
