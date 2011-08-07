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

namespace WindowsGameLibrary1
{
    public class Framework
    {

        public abstract class Entity
        { 
        }

        public class UserPrimitiveEntity<T>:Entity
        {
            private T[] _user;

            public UserPrimitiveEntity()
            {               
            }

            public T[] VertexDeclaration
            {
                set { _user = value;}
                get { return _user;}
            }
        
        
        }

        public class MovableEntity:Entity
        {
            private Vector3 _pos;
            public Vector3 Position { set { _pos = value; } get { return _pos; } }

            private Vector3 _speed;
            public Vector3 Speed { set { _speed = value; } get { return _speed; } }

            public MovableEntity(Vector3 pos, Vector3 speed)
                :base() 
            {
                _speed = speed;
                _pos = pos;
            }
        }
    }
}
