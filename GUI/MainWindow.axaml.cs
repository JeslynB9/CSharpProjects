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
        // Create an instance of Random for generating random numbers
        private readonly Random _random = new Random();

        // Constructor for MainWindow
        public MainWindow()
        {
            // Initialize the components defined in XAML
            InitializeComponent();
            // Find the TextBlock control defined in XAML with the name "HexColourTextBlock"
            HexColourTextBlock = this.FindControl<TextBlock>("HexColourTextBlock");
        }

        // Method to initialize the components
        private void InitializeComponent()
        {
            // Load the XAML layout for this window
            AvaloniaXamlLoader.Load(this);
        }

        // Event handler for button click event
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // Generate a random hexadecimal color code
            string randomHexColour = GetRandomHexColour();

            // Print the generated color to the console for debugging purposes
            Console.WriteLine("Generated colour: " + randomHexColour);

            // Create a SolidColorBrush with the generated random color
            SolidColorBrush brush = new SolidColorBrush(Color.Parse(randomHexColour));

            // Set the background color of the window to the generated color
            this.Background = brush;

            // Ensure that the HexColourTextBlock is not null before attempting to update its text
            if (HexColourTextBlock != null)
            {
                // Update the text of HexColourTextBlock to display the generated color code
                HexColourTextBlock.Text = $"{randomHexColour}";
            }
            else
            {
                // Print a warning to the console if HexColourTextBlock is null
                Console.WriteLine("HexColourTextBlock is null.");
            }
        }

        // Method to generate a random hexadecimal color code
        private string GetRandomHexColour()
        {
            // Create an array to hold the RGB values
            byte[] rgb = new byte[3];
            // Fill the array with random values
            _random.NextBytes(rgb);

            // Convert the RGB values to a hexadecimal color code and return it
            return $"#{rgb[0]:X2}{rgb[1]:X2}{rgb[2]:X2}";
        }
    }
}
