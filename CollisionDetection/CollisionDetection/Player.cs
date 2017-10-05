using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollisionDetection
{
    class Player
    {
        public Rectangle Location;
        //As a property, it wont work. A rectangle needs to be a public attribute and not a public property!
        //KIf rectangle was a class instead of a structure: it doesnt like having structures changing variables.

        public Texture2D Texture;
            //Make sure they are public attributes! 
    }
}
