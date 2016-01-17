using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectOther.States
{
    abstract class State
    {
        //StateManager in charge of moderating and updating this state.
        protected StateManager myManager;

        /// <summary>
        /// Updates the state of the state given user input.
        /// <summary>
        /// <param name="keyState"></param>
        public abstract void update(KeyboardState keyState);

        /// <summary>
        /// Draws the state.
        /// <summary>
        /// <param name="spriteBatch"></param>
        public abstract void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics);

        /// <summary>
        /// Pushes another state onto the game state stack on top of this one.
        /// <summary>
        /// <param name="newState"></param>
        public void addState(State newState)
        {
            myManager.push(newState);
        }

        /// <summary>
        /// Removes self from the game state stack.
        /// <summary>
        /// <param name="manager"></param>
        public void removeState()
        {
            if(myManager.getStates().Peek().Equals(this))
                myManager.pop();
        }
    }
}
