using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Visuals;
using Avalonia.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Tetris
{
    public partial class MainWindow : Window
    {
        // Array of the tile images used
        private readonly Bitmap[] tileImages = new Bitmap[]
        {
            new Bitmap(new Uri("Assets/TileEmpty.png", UriKind.Relative).ToString()),

            // IBlock
            new Bitmap(new Uri("Assets/Gummy Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Gummy Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Gummy Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Gummy Cat/4.png", UriKind.Relative).ToString()),

            // JBlock
            new Bitmap(new Uri("Assets/Donut Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Donut Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Donut Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Donut Cat/4.png", UriKind.Relative).ToString()),
        
            // LBlock
            new Bitmap(new Uri("Assets/Rocky Road Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Rocky Road Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Rocky Road Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Rocky Road Cat/4.png", UriKind.Relative).ToString()),

            // OBlock
            new Bitmap(new Uri("Assets/Blueberry Muffin Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Blueberry Muffin Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Blueberry Muffin Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Blueberry Muffin Cat/4.png", UriKind.Relative).ToString()),

            // SBlock
            new Bitmap(new Uri("Assets/Taro Swirl Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Taro Swirl Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Taro Swirl Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Taro Swirl Cat/4.png", UriKind.Relative).ToString()),

            // TBlock
            new Bitmap(new Uri("Assets/Choco Chip Cookie Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Choco Chip Cookie Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Choco Chip Cookie Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Choco Chip Cookie Cat/4.png", UriKind.Relative).ToString()),

            // ZBlock
            new Bitmap(new Uri("Assets/Passionfruit Icecream Cat/1.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Passionfruit Icecream Cat/2.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Passionfruit Icecream Cat/3.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Passionfruit Icecream Cat/4.png", UriKind.Relative).ToString())
        };

        // Array of block images
        private readonly Bitmap[] blockImages = new Bitmap[]
        {
            new Bitmap(new Uri("Assets/Block-Empty.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-I_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-J_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-L_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-O_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-S_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-T_BG.png", UriKind.Relative).ToString()),
            new Bitmap(new Uri("Assets/Block-Z_BG.png", UriKind.Relative).ToString())
        };

        // 2D array to hold image controls for the game grid
        private Image[,] imageControls;

        // Game state instance to manage the game's logic and state
        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            // Find and initialize the GameCanvas control
            var gameCanvas = this.FindControl<Canvas>("GameCanvas");
            if(gameCanvas == null)
            {
                throw new NullReferenceException("GameCanvas not found in XAML.");
            }
            imageControls = SetupGameCanvas(gameState.GameGrid);
            GameLoop();

            // Subscribe to the Click event of the "Play Again" button
            var playAgainButton = this.FindControl<Button>("PlayAgainButton");
            if (playAgainButton != null)
            {
                playAgainButton.Click += PlayAgain_Click;
            }
        }

        // Sets up the game canvas with image controls based on the grid size        
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25; // Size of each cell in the grid

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    // Position each image control on the canvas
                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
            return imageControls;
        }

        // Draws the current state of the game grid
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        // Draws the current active block on the grid
       private void DrawBlock(Block block)
        {
            int[] imageIndices = block.ImageIndices; // Get the image indices array

            for (int i = 0; i < block.Tiles[block.rotationState].Length; i++)
            {
                Position p = block.Tiles[block.rotationState][i]; // Get the current position in the block

                int row = p.Row + block.offset.Row;
                int col = p.Column + block.offset.Column;

                if (row >= 0 && col >= 0 && row < imageControls.GetLength(0) && col < imageControls.GetLength(1))
                {
                    int imageIndex = imageIndices[i % imageIndices.Length];
                    imageControls[row, col].Opacity = 1;  // Full opacity for the real block

                    // Adjust image rotation based on block rotation state
                    RotateTransform rotateTransform = new RotateTransform();
                    rotateTransform.Angle = block.rotationState * 90; // 90 degrees per rotation state
                    imageControls[row, col].RenderTransform = rotateTransform;

                    imageControls[row, col].Source = tileImages[imageIndex];
                }
            }
        }

        // Draws the next block in the queue
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

         // Draws the held block (if any)
        private void DrawHeldBlock(Block heldBlock)
        {
            if (heldBlock == null)
            {
                HoldImage.Source = blockImages[0];
            }
            else
            {
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }

        // Draws the ghost block, indicating where the current block will land
        private void DrawGhost(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            int i = 0; // Counter for iterating through image indices
            // Draw the ghost block
            foreach (Position p in block.TilePositions())
            {
                int ghostRow = p.Row + dropDistance;
                int ghostColumn = p.Column;

                if (ghostRow >= 0 && ghostColumn >= 0 && ghostRow < imageControls.GetLength(0) && ghostColumn < imageControls.GetLength(1))
                {
                    int imageIndex = block.ImageIndices[i % block.ImageIndices.Length];
                    imageControls[ghostRow, ghostColumn].Opacity = 0.25;

                    // Apply rotation transform
                    RotateTransform rotateTransform = new RotateTransform();
                    rotateTransform.Angle = block.rotationState * 90; // 90 degrees per rotation state
                    imageControls[ghostRow, ghostColumn].RenderTransform = rotateTransform;

                    imageControls[ghostRow, ghostColumn].Source = tileImages[imageIndex];
                }
                i++; // Increment the counter
            }
        }

        // Draws the entire game state, including grid, blocks, and UI elements
        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhost(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }

        // Main game loop that handles the game timing and updating
        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                await Task.Delay(500); // Game loop delay
                gameState.MoveBlockDown();
                Draw(gameState);
            }
            GameOverMenu.IsVisible = true;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }

        // Handles key press events for controlling the game
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    Console.WriteLine("MoveBlockLeft invoked");
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    Console.WriteLine("MoveBlockRight invoked");
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    Console.WriteLine("MoveBlockDown invoked");
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    Console.WriteLine("RotateBlockCW invoked");
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    Console.WriteLine("RotateBlockCCW invoked");
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    Console.WriteLine("HoldBlock invoked");
                    gameState.HoldBlock();
                    break;
                case Key.LeftShift:
                    Console.WriteLine("DropBlock invoked");
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gameState);
        }

        // Event handler for when the window is attached to the visual tree
        private void MainWindow_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            GameCanvas_Loaded();
        }

        // Event handler for when the game canvas is loaded
        private async void GameCanvas_Loaded()
        {
            await GameLoop();
        }

        // Event handler for the "Play Again" button click
        private async void PlayAgain_Click(object sender, EventArgs e)
        {
            gameState = new GameState(); // Reset game state
            GameOverMenu.IsVisible = false;
            await GameLoop();
        }
        
    }
}
