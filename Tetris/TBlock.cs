namespace Tetris
{
    public class TBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(0, 1), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(1, 2) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 1) }
        };
        protected readonly int[] imageIndices = { 21, 22, 23, 24 };
        public override int Id => 6;
        public override Position StartOffset => new Position(-1, 3);
        public override Position[][] Tiles => tiles;
        public override int[] ImageIndices => imageIndices;
    }
}