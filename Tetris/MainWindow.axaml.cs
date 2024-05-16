using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Visuals;
using Avalonia.Media;
using System;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Tetris
{
    public partial class MainWindow : Window
    {
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

        private Image[,] imageControls;

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
        
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
            return imageControls;
        }

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
                    imageControls[p.Row, p.Column].Opacity = 1;

                    // Adjust image rotation based on block rotation state
                    RotateTransform rotateTransform = new RotateTransform();
                    rotateTransform.Angle = block.rotationState * 90; // 90 degrees per rotation state
                    imageControls[row, col].RenderTransform = rotateTransform;

                    imageControls[row, col].Source = tileImages[imageIndex];
                }
            }
        }

        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

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

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhost(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }

        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                await Task.Delay(500);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
            GameOverMenu.IsVisible = true;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gameState);
        }

        private void MainWindow_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            GameCanvas_Loaded();
        }

        private async void GameCanvas_Loaded()
        {
            await GameLoop();
        }

        private async void PlayAgain_Click(object sender, EventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.IsVisible = false;
            await GameLoop();
        }
    }
}
