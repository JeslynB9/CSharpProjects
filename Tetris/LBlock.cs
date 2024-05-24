namespace Tetris
{
    // Concrete class representing the 'L' shaped Tetris block
    public class LBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'L' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 2), new(1, 2), new(1, 1), new(1, 0) },
            new Position[] { new(2, 2), new(2, 1), new(1, 1), new(0, 1) },
            new Position[] { new(2, 0), new(1, 0), new(1, 1), new(1, 2) },
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(2, 1) }
        };

        // Array holding image indices for rendering the 'L' block in different states
        protected readonly int[] imageIndices = { 9, 10, 11, 12 };

        // Unique identifier for the 'L' block
        public override int Id => 3; 

        // Starting offset position for the 'L' block 
        public override Position StartOffset => new Position(0, 3);

        // Property to get the tile positions for the 'L' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'L' block
        public override int[] ImageIndices => imageIndices;
    }
}