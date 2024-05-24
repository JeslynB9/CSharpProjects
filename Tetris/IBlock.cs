namespace Tetris
{
    // Concrete class representing the 'I' shaped Tetris block
    public class IBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'I' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2) },
            new Position[] { new(1, 3), new(1, 2), new(1, 1), new(1, 0) },
            new Position[] { new(3, 1), new(2, 1), new(1, 1), new(0, 1) },
            new Position[] { new(2, 0), new(2, 1), new(2, 2), new(2, 3) }
        };

        // Array holding image indices for rendering the 'I' block in different states
        protected readonly int[] imageIndices = { 1, 2, 3, 4 };

        // Unique identifier for the 'I' block
        public override int Id => 1; 

        // Starting offset position for the 'I' block
        public override Position StartOffset => new Position(-1, 3);

        // Property to get the tile positions for the 'I' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'I' block
        public override int[] ImageIndices => imageIndices;
    }
}