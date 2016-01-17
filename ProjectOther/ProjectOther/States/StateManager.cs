using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Container for layered game states.
/// Contains a stack of game states, the top of which is actively
/// updated and rendered. 
/// <summary>
namespace ProjectOther.States
{
    class StateManager
    {
        Stack<State> states;

        public StateManager()
        {
            states = new Stack<State>();
        }

        /// <summary>
        /// Update the first state in the stack.
        /// </summary>
        /// <param name="inputState"></param>
        public void update(KeyboardState inputState)
        {
            states.Peek().update(inputState);
        }

        /// <summary>
        /// Render the first state in the stack.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            states.Peek().draw(spriteBatch, graphics);
        }

        /// <summary>
        /// Remove the first state in the stack.
        /// </summary>
        public void pop()
        {
            states.Pop();
        }

        /// <summary>
        /// Add a new stack to the top of the game state stack.
        /// </summary>
        /// <param name="newState"></param>
        public void push(State newState)
        {
            states.Push(newState);
        }

        public Stack<State> getStates()
        {
            return states;
        }

        public void setStates(Stack<State> newStates)
        {
            states = newStates;
        }
    }
}
