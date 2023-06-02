using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Bullets
{
    public Texture2D bullet;
    public Vector2 bulletPosition;
    public Vector2 bulletVelocity;
    public Vector2 bulletOrigin;
    public bool isVisible;
    public Bullets (Texture2D newTexture)
    {
        bullet = newTexture;
        isVisible = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(bullet,bulletPosition,null,Color.Yellow,0f,bulletOrigin,4f,SpriteEffects.None,0);
    }
}