using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_HW_3_Actual_Final
{
    public class Collectible : GameObject
    {
        public bool Active { get; set; }
        public Collectible(int x, int y, int width, int height): base(x,y,width,height)
        {
            Active = true;            
        }
        //Like any game object, set the coordinates and size of the object through parameters
        //Make sure that it is active so that it is drawn and so that the player can collect it

        public bool Collision(Player pL)
        {
            if (this.Active)
            {
                if (this.Position.Intersects(pL.Position))
                {
                    return true;
                }
            }
                   
                return false;           
        }
        //If the object is active, check collision
        //If the object collides with a player, 
        //Return true
        
        public override void Draw(SpriteBatch sB)
        {
            if (Active == true)
            {
                sB.Draw(this.Texture, this.Position, Color.White);
            }
        }
        //If the sprite is active (as in it hasnt been picked up),
        //then draw the object
    }
}
