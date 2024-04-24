namespace Tetris
{
    public class ZBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },
            new Position[] { new(0, 2), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 0) }
        };
        protected readonly int[] imageIndices = { 25, 26, 27, 28 };
        public override int Id => 7; 
        public override Position StartOffset => new Position(-1, 3);
        public override Position[][] Tiles => tiles;
        public override int[] ImageIndices => imageIndices;
    }
}