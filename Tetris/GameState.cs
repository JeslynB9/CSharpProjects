using System;
using System.ComponentModel.Design;


namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        // Property for accessing the current block
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                // Attempts to move the block down twice to its starting position
                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    // If the block doesn't fit, move it back up
                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        // The grid representing the game area
        public GameGrid GameGrid { get; }

        // Queue for managing the upcoming blocks
        public BlockQueue BlockQueue { get; }

        // Indicates if the game is over
        public bool GameOver { get; private set;}

        // Tracks the player's score
        public int Score { get; private set;}

        // The block currently held by the player
        public Block HeldBlock { get; private set;}

        // Indicates if the player can hold a block
        public bool CanHold { get; private set;}

        // Constructor initializing the game grid and block queue
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        // Checks if current block is in a legal position or not
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column) || p.Row >= GameGrid.Rows)
                {
                    return false;
                }
            }
            return true;
        }

        // Allows the player to hold a block
        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else{
                Block temp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = temp;
            }

            CanHold = false;
        }

        // Rotate the current block clockwise, only if it is possible from where it is
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        // Rotate the block counter clockwise, only if it is possible from where it is
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        // Move block left, only if it is possible from where it is
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        // Move block right, only if it is possible from where it is
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        // Checks if game is over
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        // If current block cannot be moved down
        public void PlaceBlock()
        {
            foreach (Position tilePosition in this.CurrentBlock.Tiles[this.CurrentBlock.rotationState])
            {
                // Get the index of the tile in the block
                int tileIndex = Array.IndexOf(this.CurrentBlock.Tiles[this.CurrentBlock.rotationState], tilePosition);
                
                // Get the corresponding image index
                int imageIndex = this.CurrentBlock.ImageIndices[tileIndex];
                
                // Calculate the position for the current image index
                Position blockPosition = new Position(tilePosition.Row + this.CurrentBlock.offset.Row, tilePosition.Column + this.CurrentBlock.offset.Column);
                
                Console.WriteLine($"Setting image index {imageIndex} at position {blockPosition.Row},{blockPosition.Column}");
                
                // Set the image index in the game grid at the calculated position
                GameGrid[blockPosition.Row, blockPosition.Column] = imageIndex;
            }

            Score += GameGrid.ClearFullRows(); 

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                this.CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        // Move block down
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0); // Move the block back up
                PlaceBlock(); // Place the block when it cannot move down anymore
            }
        }

        // Calculates the distance a tile can drop
        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        // Calculates the maximum distance the current block can drop
        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach ( Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        // Drops the current block to the bottom and places it
        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }

    }
}