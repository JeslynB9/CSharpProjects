namespace Tetris
{
    // Concrete class representing the 'Z' shaped Tetris block
    public class ZBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'Z' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },
            new Position[] { new(0, 2), new(1, 2), new(1, 1), new(2, 1) },
            new Position[] { new(2, 2), new(2, 1), new(1, 1), new(1, 0) },
            new Position[] { new(2, 0), new(1, 0), new(1, 1), new(0, 1) }
        };

        // Array holding image indices for rendering the 'Z' block in different states
        protected readonly int[] imageIndices = { 25, 26, 27, 28 };

        // Unique identifier for the 'Z' block
        public override int Id => 7; 

        // Starting offset position for the 'Z' block 
        public override Position StartOffset => new Position(-1, 3);

        // Property to get the tile positions for the 'Z' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'Z' block
        public override int[] ImageIndices => imageIndices;
    }
}