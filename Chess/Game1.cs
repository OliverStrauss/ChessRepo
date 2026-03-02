using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Board b;
    private Texture2D _pixel;

    private int width = 1280;
    private int height = 720;
    private Vector2 boardPosition = new Vector2(200, 40);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        b = new Board();
        Console.WriteLine(b);
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    public void drawBoard()
    {
        int tileSize = 48; 
        int boardSize = 8; 
    
        // 1. Calculate the starting PIXEL offsets once, outside the loop
        float startPixelX = (boardPosition.X);
    
        // (Optional: You can center it vertically too!)
        // int startPixelY = (height / 2) - ((tileSize * boardSize) / 2); 
        float startPixelY = (boardPosition.Y); // Or whatever top margin you want

        // 2. Loop through the GRID positions (0 to 7)
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                // 3. Color math uses the grid (0-7), NOT the pixels
                Color tileColor = (x + y) % 2 == 0 ? Color.Wheat : Color.SaddleBrown;

                // 4. Position = Starting Offset + (Grid Index * Tile Size)
                Rectangle tileRect = new Rectangle(
                    (int)startPixelX + (x * tileSize), 
                    (int)startPixelY + (y * tileSize), 
                    tileSize, 
                    tileSize
                );

                // Draw the stretched pixel
                _spriteBatch.Draw(_pixel, tileRect, tileColor);
            }
        }
    }

    public void overlayPeices()
    {
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        drawBoard();
       
        _spriteBatch.End();

        base.Draw(gameTime);
    }
    
}
