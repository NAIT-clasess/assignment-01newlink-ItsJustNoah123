using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnim;

namespace Assignment_01;

public class Game1 : Game
{
    // Graphics device manager for handling graphics settings
    private GraphicsDeviceManager _graphics;
    // SpriteBatch for drawing textures
    private SpriteBatch _spriteBatch;
    // Texture for the space background
    private Texture2D _space;
    //Texture for the asteroid
    private Texture2D _asteroid;
    // Texture for the spaceship
    private Texture2D _spaceship;
    // Store window dimensions
    private int _windowWidth;
    private int _windowHeight;
    //Store animation for spaceship
    private SimpleAnimation _spaceshipAnimation;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        // Get the current window dimensions
        _windowWidth = GraphicsDevice.Viewport.Width;
        _windowHeight = GraphicsDevice.Viewport.Height;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // Load the space station texture
        _space = Content.Load<Texture2D>("Space");
        // Load the asteroid texture
        _asteroid = Content.Load<Texture2D>("asteroids (SMALL)");
        //load the spaceship texture
        _spaceshipAnimation = new SimpleAnimation(Content.Load<Texture2D>("Evasion"), 192, 192, 9, 15f);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        _spaceshipAnimation.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        // Draw the space texture to cover the entire window using stored dimensions
        _spriteBatch.Draw(_space, new Rectangle(0, 0, _windowWidth, _windowHeight), Color.White);
        // Draw the asteroid texture at position (100, 100)
        _spriteBatch.Draw(_asteroid, new Vector2(100, 100), Color.White);
        _spaceshipAnimation.Draw(_spriteBatch, new Vector2(200, 200), SpriteEffects.None);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
