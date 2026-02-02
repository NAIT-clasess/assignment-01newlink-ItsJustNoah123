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
    // Store window dimensions
    private int _windowWidth;
    private int _windowHeight;
    //Store animation for spaceship
    private SimpleAnimation _spaceshipAnimation;
    //store 2nd spaceship animation
    private SimpleAnimation _spaceshipAnimation2;
    //Store asteroid speed
    private float _asteroidSpeed;
    //store asteroid position
    private Vector2 _asteroidPosition;
    // Store game font
    private SpriteFont _gameFont;
    // Store idle sprite for player character
    private Texture2D _idleSprite;
    // Store player position
    private Vector2 _playerPosition;
    // Store player movement speed
    private float _playerSpeed = 200f;
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
        // Initialize asteroid speed
        _asteroidSpeed = 20f;
        // Initialize asteroid position
        _asteroidPosition = new Vector2(100, 100);
        // Initialize player position to center of screen
        _playerPosition = new Vector2(_windowWidth / 2, _windowHeight / 2);
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
        _spaceshipAnimation = new SimpleAnimation(Content.Load<Texture2D>("Evasion"), 192, 192, 9, 6f);
        // Load the game font
        _gameFont = Content.Load<SpriteFont>("gamefont");
        //load the 2nd spaceship texture
        _spaceshipAnimation2 = new SimpleAnimation(Content.Load<Texture2D>("Attack_1"), 192, 192, 4, 6f);
        // Load the idle sprite for player character
        _idleSprite = Content.Load<Texture2D>("Idle");
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        // Update the spaceship animations
        _spaceshipAnimation.Update(gameTime);
        _spaceshipAnimation2.Update(gameTime);
        // Move the asteroid to the right and loop it back to the left side when it goes off screen
        _asteroidPosition.X += _asteroidSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_asteroidPosition.X > _windowWidth)
        {
            _asteroidPosition.X = -_asteroid.Width;
        }
        // Handle keyboard input for player movement
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
        {
            _playerPosition.Y -= _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
        {
            _playerPosition.Y += _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
        {
            _playerPosition.X -= _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
        {
            _playerPosition.X += _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        // Keep player within screen bounds
        _playerPosition.X = MathHelper.Clamp(_playerPosition.X, 0, _windowWidth - _idleSprite.Width);
        _playerPosition.Y = MathHelper.Clamp(_playerPosition.Y, 0, _windowHeight - _idleSprite.Height);
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
        _spriteBatch.Draw(_asteroid, _asteroidPosition, Color.White);
        // Draw the spaceship animation at the right side of the screen, centered vertically
        _spaceshipAnimation.Draw(_spriteBatch, new Vector2(_windowWidth - 250, _windowHeight / 2 - 96), SpriteEffects.None);
        // Draw the 2nd spaceship animation at the left side of the screen, centered vertically
        _spaceshipAnimation2.Draw(_spriteBatch, new Vector2(50, _windowHeight / 2 - 96), SpriteEffects.None);
        // Draw the idle sprite (player character) at the controlled position
        _spriteBatch.Draw(_idleSprite, _playerPosition, Color.White);
        //Draw the "SPACE" font at the top center of the screen
        _spriteBatch.DrawString(_gameFont, "SPACE WARS", new Vector2(180, 20), Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
