using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BasicModel
{
    
    class Input
    {
        KeyboardState _prevkbstate;
        KeyboardState _currentkbstate;

        public Input() 
        {
            _currentkbstate = Keyboard.GetState();
            _prevkbstate = _currentkbstate;
        }

        public void update()
        {
            _prevkbstate = _currentkbstate;
            _currentkbstate = Keyboard.GetState();
        }

        public bool right
        {
            get
            {
                return _currentkbstate.IsKeyDown(Keys.Right);
            }
        }


        public bool left
        {
            get
            {
                return _currentkbstate.IsKeyDown(Keys.Left);
            }
        }

        public bool up
        {
            get
            {
                return _currentkbstate.IsKeyDown(Keys.Up);
            }
        }


        public bool down
        {
            get
            {
                return _currentkbstate.IsKeyDown(Keys.Down);
            }
        }
    }
}
