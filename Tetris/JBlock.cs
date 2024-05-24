namespace Tetris
{
    // Concrete class representing the 'J' shaped Tetris block
    public class JBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'J' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(1, 0), new(1, 1), new(1, 2) },
            new Position[] { new(0, 2), new(0, 1), new(1, 1), new(2, 1) },
            new Position[] { new(2, 2), new(1, 2), new(1, 1), new(1, 0) },
            new Position[] { new(2, 0), new(2, 1), new(1, 1), new(0, 1) }
        };

        // Array holding image indices for rendering the 'J' block in different states
        protected readonly int[] imageIndices = { 5, 6, 7, 8 };

        // Unique identifier for the 'J' block
        public override int Id => 2;

        // Starting offset position for the 'J' block 
        public override Position StartOffset => new Position(0, 3);

        // Property to get the tile positions for the 'J' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'J' block
        public override int[] ImageIndices => imageIndices;
    }
}