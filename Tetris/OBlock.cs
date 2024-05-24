namespace Tetris
{
    // Concrete class representing the 'O' shaped Tetris block
    public class OBlock : Block
    {
        // Multidimensional array defining the tile positions for each rotation state of the 'O' block, in this case, 'O' block only
        // has one rotation state
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) }
        };

        // Array holding image indices for rendering the 'O' block in different states
        protected readonly int[] imageIndices = { 13, 14, 15, 16 };

        // Unique identifier for the 'O' block
        public override int Id => 4; 

        // Starting offset position for the 'O' block
        public override Position StartOffset => new Position(0, 4);

        // Property to get the tile positions for the 'O' block
        public override Position[][] Tiles => tiles;

        // Property to get the image indices for the 'O' block
        public override int[] ImageIndices => imageIndices;
    }
}