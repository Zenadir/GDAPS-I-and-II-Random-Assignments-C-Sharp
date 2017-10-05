using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_HW_3_Actual_Final
{
    public class GameObject
    {
        public Rectangle Position = new Rectangle();
        public Texture2D Texture;
        
        public GameObject(int x, int y, int width, int height)
        {
            Position.X = x;
            Position.Y = y;
            Position.Width = width;
            Position.Height = height;
        }
        //Takes the position and size of any given game object. 

        public virtual void Draw(SpriteBatch sB)
        {
            sB.Draw(this.Texture, this.Position, Color.White);
        }
        //Have the object draw itself with its own texture and position. 
    }
}
