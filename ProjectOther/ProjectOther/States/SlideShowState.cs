using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework;
using MyDataTypes;
using ProjectOther.Util;

namespace ProjectOther.States
{
    /// <summary>
    /// State displaying a series of images.
    /// </summary>
    class SlideShowState : State
    {
        //Flag that determines whether slides can be skipped through.
        Boolean skippable;
        //Time in milliseconds to spend on each slide. 
        //A negative value will result in the slide not advancing.
        int timePerSlide;

        //Image queue to iterate through.
        Queue<Texture2D> slides;

        //Game settings.
        Configuration config;

        public SlideShowState()
        {
            this.skippable = true;
            this.timePerSlide = 300;
            Timer slideTimer = new Timer(timePerSlide);
            slideTimer.Elapsed += OnTimedEvent;
            config = Utils.loadConfig();
        }

        public SlideShowState(Queue<Texture2D> s, Boolean skip, int duration)
        {
            this.slides = s;
            this.skippable = skip;
            this.timePerSlide = duration;
            if(duration > 0)
            {
                Timer slideTimer = new Timer(timePerSlide);
                slideTimer.Elapsed += OnTimedEvent;
            }
            config = Utils.loadConfig();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.slides.Dequeue();
            //Remove the Slide Show State if it is out of images.
            if (this.slides.Count == 0)
            {
                myManager.pop();
            }
        }

        public void addSlide(Texture2D slide)
        {
            this.slides.Enqueue(slide);
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            //Draw to fill screen.
            double scale = Math.Min((double)graphics.PreferredBackBufferWidth / slides.Peek().Width, 
                (double)graphics.PreferredBackBufferHeight / slides.Peek().Height);
            spriteBatch.Draw(slides.Peek(), destinationRectangle: new Rectangle((int)Math.Ceiling(graphics.PreferredBackBufferWidth - slides.Peek().Width * scale) / 2,
                (int)Math.Ceiling(graphics.PreferredBackBufferHeight - slides.Peek().Height * scale) / 2, (int)Math.Ceiling(slides.Peek().Width * scale), 
                (int)Math.Ceiling(slides.Peek().Height * scale)));
        }

        public override void update(KeyboardState keyState)
        {
            //Go to next slide when prompted, if skipping is allowed.
            if(skippable)
            {

            }
        }
    }
}