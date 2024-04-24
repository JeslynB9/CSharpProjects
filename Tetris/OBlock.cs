namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) }
        };

        protected readonly int[] imageIndices = { 13, 14, 15, 16 };
        public override int Id => 4; 
        public override Position StartOffset => new Position(0, 4);
        public override Position[][] Tiles => tiles;
        public override int[] ImageIndices => imageIndices;
    }
}