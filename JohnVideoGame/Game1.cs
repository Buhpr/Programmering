using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JohnVideoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D MainChar;
    Texture2D pixel;
    Texture2D bfg;
    Texture2D EvilGuy;
    Rectangle MainCharBody;
    Rectangle EvilGuyBody = new Rectangle(256,256,32,32);
    Rectangle LeftWall = new Rectangle(0,0,8,512);
    Rectangle RightWall = new Rectangle(504,0,8,512);
    Rectangle TopWall = new Rectangle(0,0,512,32);
    Rectangle BottomWall = new Rectangle(0,504,512,8);
    Rectangle HealthBG = new Rectangle(16,16,100,8);
    Rectangle HealthBar = new Rectangle(16,16,100,8);
    Rectangle gunRectangle;
    //Rectangle HealthUp = new Rectangle(100,100)
    SpriteFont Font;
    int PlayerSpeed = 4;
    int HP = 100;
    bool playerIsVisible = true;
    KeyboardState oldState;
    Vector2 distance;
    Vector2 spriteOrigin;
    Vector2 spritePosition;
    Vector2 playerPosition;
    float rotation;

    //bullets
    List<Bullets> bullets = new List<Bullets>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 512;
        _graphics.PreferredBackBufferHeight = 512;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }


    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        MainChar = Content.Load<Texture2D>("MainChar");
        pixel = Content.Load<Texture2D>("pixel");
        Font = Content.Load<SpriteFont>("font");
        bfg = Content.Load<Texture2D>("bfg");
        EvilGuy = Content.Load<Texture2D>("EvilGuy");
        playerPosition = new Vector2(224,224);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kState = Keyboard.GetState();

            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - spritePosition.X;
            distance.Y = mouse.Y - spritePosition.Y;

            rotation = (float)Math.Atan2(distance.Y,distance.X);
            spritePosition = new Vector2(playerPosition.X, playerPosition.Y);

            gunRectangle = new Rectangle((int)spritePosition.X,(int)spritePosition.Y,bfg.Width,bfg.Height);
            spriteOrigin = new Vector2(gunRectangle.Width / 2,gunRectangle.Height / 2);

            if(Keyboard.GetState().IsKeyDown(Keys.C) && oldState.IsKeyUp(Keys.C) && HP > 0)
            {
                HP-=25;
                HealthBar.Width-=25;
                    if(HP <= 0)
                    {
                        playerIsVisible = false;
                    }
            }

            if(kState.IsKeyDown(Keys.W) && playerPosition.Y >= 50 && HP > 0)
            {
                playerPosition.Y -= PlayerSpeed;
            }
            if(kState.IsKeyDown(Keys.S) && playerPosition.Y <= 484 && HP > 0)
            {
                playerPosition.Y += PlayerSpeed;
            }
            if(kState.IsKeyDown(Keys.A) && playerPosition.X >= 26 && HP > 0)
            {
                playerPosition.X -= PlayerSpeed;
            }
            if(kState.IsKeyDown(Keys.D) && playerPosition.X <= 486 && HP > 0)
            {
                playerPosition.X += PlayerSpeed;
            }
            if(kState.IsKeyDown(Keys.LeftShift))
            {
                PlayerSpeed = 2;
            }
            else
            {
                PlayerSpeed = 4;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space) && HP > 0)
                Shoot();
            UpdateBullets();
            oldState = kState;

        base.Update(gameTime);
    }

    public void UpdateBullets()
    {
        foreach(Bullets bullet in bullets)
        {
            bullet.bulletPosition += bullet.bulletVelocity;
                if(Vector2.Distance(bullet.bulletPosition,spritePosition) > 725)
                    bullet.isVisible = false;
        }
        for(int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].isVisible)
            {
                bullets.RemoveAt(i);
                i--;
            }
        }
    }

    public void Shoot()
    {
        Bullets newBullet = new Bullets(Content.Load<Texture2D>("bullet"));
        newBullet.bulletVelocity = new Vector2((float)Math.Cos(rotation),(float)Math.Sin(rotation)) * 5f;
        newBullet.bulletPosition = playerPosition + newBullet.bulletVelocity * 5;
        newBullet.isVisible = true;

        if(bullets.Count() < 20)
        {
            bullets.Add(newBullet);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        Vector2 fontsize = Font.MeasureString("You died \n   Idiot!");
        _spriteBatch.Begin(samplerState:SamplerState.PointClamp);
        _spriteBatch.Draw(MainChar,playerPosition,null,Color.White,0,spriteOrigin,2f,SpriteEffects.None,0);
        _spriteBatch.Draw(pixel,LeftWall,Color.White);
        _spriteBatch.Draw(pixel,RightWall,Color.White);
        _spriteBatch.Draw(pixel,TopWall,Color.White);
        _spriteBatch.Draw(pixel,BottomWall,Color.White);
        _spriteBatch.Draw(pixel,HealthBG,Color.Gray);
        _spriteBatch.Draw(pixel,HealthBar,Color.Red);
        _spriteBatch.Draw(EvilGuy,EvilGuyBody,Color.White);
        foreach(Bullets bullet in bullets)
            bullet.Draw(_spriteBatch);
        _spriteBatch.Draw(bfg,spritePosition,null,Color.White,rotation,spriteOrigin,2f,SpriteEffects.None,0);
        if(HP <= 0)
        {
        _spriteBatch.DrawString(Font,"You died \n   Idiot!",new Vector2(160,80),Color.White);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}