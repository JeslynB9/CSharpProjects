using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;

namespace GUI
{
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            HexColourTextBlock = this.FindControl<TextBlock>("HexColourTextBlock");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // Generate random hexadecimal colour
            string randomHexColour = GetRandomHexColour();

            // Print the generated colour (for debugging)
            Console.WriteLine("Generated colour: " + randomHexColour);

            // Create a SolidColourBrush with the random colour
            SolidColourBrush brush = new SolidColourBrush(Colour.Parse(randomHexColour));

            // Set background colour of window
            this.Background = brush;

            // Ensure HexColourTextBlock is not null before accessing its properties
            if (HexColourTextBlock != null)
            {
                // Update the text block with the hexadecimal colour code
                HexColourTextBlock.Text = $"This colour is: {randomHexColour}";
            }
            else
            {
                Console.WriteLine("HexColourTextBlock is null.");
            }
        }

        private string GetRandomHexColour()
        {
            // Generate random RGB values
            byte[] rgb = new byte[3];
            _random.NextBytes(rgb);

            // Convert RGB to hexadecimal colour code
            return $"#{rgb[0]:X2}{rgb[1]:X2}{rgb[2]:X2}";
        }
    }
}
