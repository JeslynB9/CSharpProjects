using System.Collections.Generic;
namespace Tetris
{
    public abstract class Block
    {
        public abstract Position[][] Tiles { get; }
        public abstract Position StartOffset { get; }
        public abstract int[] ImageIndices { get; }
        public abstract int Id { get; }
        public int rotationState;
        public Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
    {
        foreach (Position p in Tiles[rotationState])
        {
            yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
        }
    }


        // Rotate the block clockwise
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Rotate the block anticlockwise
        public void RotateCCW()
        {
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