namespace Tetris
{
    // Concrete class representing the 'T' shaped Tetris block
    public class TBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'T' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(0, 1), new(1, 1), new(2, 1), new(1, 0) },
            new Position[] { new(1, 2), new(1, 1), new(1, 0), new(0, 1) },
            new Position[] { new(2, 1), new(1, 1), new(0, 1), new(1, 2) }
        };

        // Array holding image indices for rendering the 'T' block in different states
        protected readonly int[] imageIndices = { 21, 22, 23, 24 };

        // Unique identifier for the 'T' block
        public override int Id => 6;

        // Starting offset position for the 'T' block 
        public override Position StartOffset => new Position(-1, 3);

        // Property to get the tile positions for the 'T' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'T' block
        public override int[] ImageIndices => imageIndices;
    }
}