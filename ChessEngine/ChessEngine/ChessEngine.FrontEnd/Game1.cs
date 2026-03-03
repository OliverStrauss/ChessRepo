using System;
using System.Collections.Generic;
using ChessEngine.Engine;
using ChessEngine.Library;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame;


namespace ChessEngine.FrontEnd;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    SpriteFont font;
    
    private MouseState _previousMouse;
    private MouseState _currentMouse;

    private Point? _selectedSquare = null;

    
    private Board b;
    private Texture2D _pixel;
    
    int tileSize = 48;
    private int width = 1280;
    private int height = 720;
    private List<Move> availableMoves;
    
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
        font = Content.Load<SpriteFont>("DefaultFont"); 

        // TODO: use this.Content to load your game content here
    }
    
    

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _currentMouse = Mouse.GetState();

        if (_currentMouse.LeftButton == ButtonState.Pressed &&
            _previousMouse.LeftButton == ButtonState.Released)
        {
            HandleClick(_currentMouse.Position);
        }

        _previousMouse = _currentMouse;


        // TODO: Add your update logic here

        base.Update(gameTime);
    }
    
    private void HandleClick(Point mousePos)
    {
    

        int boardX = (int)((mousePos.X - boardPosition.X) / tileSize);
        int boardY = (int)((mousePos.Y - boardPosition.Y) / tileSize);

        if (boardX < 0 || boardX > 7 || boardY < 0 || boardY > 7)
            return;

        Console.WriteLine($"Clicked: {boardX},{boardY}");
        
        Peice peice = b.getPeice(boardX, boardY);
       // availableMoves = Move.GetLegalMoves(peice);
        Console.WriteLine(availableMoves);

        if (_selectedSquare == null)
        {
            _selectedSquare = new Point(boardX, boardY);
        }
        else
        {
            // Attempt move
            var from = _selectedSquare.Value;
            var to = new Point(boardX, boardY);

            // Later this becomes:
            // b.TryMakeMove(from, to);

            Console.WriteLine($"Move {from} -> {to}");
            
            b.movePeice(from.Y, from.X, to.Y, to.X);
            Console.WriteLine(b);

            _selectedSquare = null;
        }
    }

    
    public void drawBoard()
    {
        int boardSize = 8; 

        float startPixelX = boardPosition.X;
        float startPixelY = boardPosition.Y;

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                var piece = b.getPeice(y, x);

                // Base tile color
                Color tileColor = (x + y) % 2 == 0 ? Color.Wheat : Color.SaddleBrown;

                Rectangle tileRect = new Rectangle(
                    (int)startPixelX + (x * tileSize),
                    (int)startPixelY + (y * tileSize),
                    tileSize,
                    tileSize
                );

                // Draw base tile
                _spriteBatch.Draw(_pixel, tileRect, tileColor);

                // Highlight available moves
                if (availableMoves != null)
                {
                    foreach (var move in availableMoves)
                    {
                        int targetX = (int)move.getEndPos().X;
                        int targetY = (int)move.getEndPos().Y;

                        if (targetX == x && targetY == y)
                        {
                            // Semi-transparent overlay for available move
                            _spriteBatch.Draw(_pixel, tileRect, new Color(0, 255, 0, 128)); // Green with 50% alpha
                        }
                    }
                }

                // Draw piece if present
                if (piece != null)
                {
                    string symbol = piece.ToString();
                    Vector2 textSize = font.MeasureString(symbol);

                    Vector2 textPosition = new Vector2(
                        (int)startPixelX + (x * tileSize) + (tileSize - textSize.X) / 2,
                        (int)startPixelY + (y * tileSize) + (tileSize - textSize.Y) / 2
                    );

                    _spriteBatch.DrawString(
                        font,
                        symbol,
                        textPosition,
                        piece.IsWhite() ? Color.White : Color.Black
                    );
                }
            }
        }
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
