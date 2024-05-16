using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Define ASCII frames for cat moving its head animation
        string[] frames =
        {
@"     /\_/\
    ( o.o )/ )
     > ^ <( (
    /   \ ) )
   (_/^\_)_/",
@"   /\_/\ 
  ( -.- )  / )
   > ^ <  ( (
    /   \ ) )
   (_/^\_)_/"
        };

        // Clear console and set cursor position to the top-left corner
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        // Animation loop
        while (true)
        {
            foreach (string frame in frames)
            {
                Console.WriteLine(frame);
                // Delay between frames (adjust as needed)
                Thread.Sleep(300);
                // Clear the console for next frame
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}


