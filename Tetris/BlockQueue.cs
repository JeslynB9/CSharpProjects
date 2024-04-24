using System;

namespace Tetris
{
    public class BlockQueue
    {
        public readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random();
        public Block NextBlock { get; private set; }

        // Constructor
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        // Returns a random block
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // returnsd the next block and updates the property
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }

    }
}