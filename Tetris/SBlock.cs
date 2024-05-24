namespace Tetris
{
    // Concrete class representing the 'S' shaped Tetris block
    public class SBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'S' block
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 1), new(0, 2), new(1, 0), new(1, 1) },
            new Position[] { new(1, 2), new(2, 2), new(0, 1), new(1, 1) },
            new Position[] { new(2, 1), new(2, 0), new(1, 2), new(1, 1) },
            new Position[] { new(1, 0), new(0, 0), new(2, 1), new(1, 1) }
        };

        // Array holding image indices for rendering the 'S' block in different states
        protected readonly int[] imageIndices = { 17, 18, 19, 20 };

        // Unique identifier for the 'S' block
        public override int Id => 5; 

        // Starting offset position for the 'S' block 
        public override Position StartOffset => new Position(0, 3);

        // Property to get the tile positions for the 'S' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'S' block
        public override int[] ImageIndices => imageIndices;
    }
}