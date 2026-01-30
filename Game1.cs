using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    // Graphics device manager for handling graphics settings
    private GraphicsDeviceManager _graphics;
    // SpriteBatch for drawing textures
    private SpriteBatch _spriteBatch;
    // Texture for the space background
    private Texture2D _space;
    // Store window dimensions
    private int _windowWidth;
    private int _windowHeight;
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
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        // Draw the space texture to cover the entire window
        _spriteBatch.Draw(_space, new Rectangle(0, 0, _windowWidth, _windowHeight), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
