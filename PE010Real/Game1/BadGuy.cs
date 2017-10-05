using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class BadGuy
    {
        public Rectangle Location;
        public Texture2D Texture;
        public Color badColor = Color.White;
        public bool Active { get; set; }

        public BadGuy()
        {
            Active = true;
        }

        public void CheckCollision(Player play)
        {
            if (this.Location.Intersects(play.Location))
            {
                this.badColor = Color.Blue;
                this.Location = new Rectangle(this.Location.X, this.Location.Y, this.Location.Width - 3, this.Location.Height - 3);
                if(this.Location.Height <= 20)
                {
                    this.Active = false;
                }
            }
        }
    }
}
