using System.Collections.Generic;
namespace Tetris
{
    // Abstract class representing a generic Tetris block
    public abstract class Block
    {
        // Abstract properties to be implemented by derived classes
        public abstract Position[][] Tiles { get; } // Multidimensional array holding block tiles for each rotation state
        public abstract Position StartOffset { get; } // Starting position offset for the block
        public abstract int[] ImageIndices { get; } // Image indices for rendering the block
        public abstract int Id { get; } // Unique identifier for the block type

        // Fields for the current rotation state and position offset
        public int rotationState;
        public Position offset;

        // Constructor initializing the block's position to its starting offset
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        // Method to get the current tile positions of the block based on its rotation and offset
        public IEnumerable<Position> TilePositions()
    {
        foreach (Position p in Tiles[rotationState])
        {
            // Yield return each tile position adjusted by the current offset
            yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
        }
    }


        // Rotate the block clockwise
        public void RotateCW()
        {
            // Update rotation state cyclically within the bounds of the Tiles array
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Rotate the block anticlockwise
        public void RotateCCW()
        {
            // Update rotation state cyclically in the reverse direction
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        // Move the block down
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Resets the rotation and position
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }

        
    }
}