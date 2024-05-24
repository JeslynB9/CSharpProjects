# SelfLearningAdvanced
The practical application for my Self-Learning Advanced Project

## How to run
Inorder to run all three projects, you need to install Avalonia first, here are the installation instructions.

### Prerequisites
- .NET Core SDK installed

### Installation Steps
1. Open your terminal or command prompt.
2. Search for Avalonia using the following command:
  ``` bash
  dotnet new seach avalonia
  ```
3. Install Avalonia with this command:
  ``` bash
  dotnet new --install Avalonia.Templates
  ```
4. Verify Avalonia has been installed correctly using this command:
  ``` bash
  dotnet new list
  ```
  
 The first time building and running all of these projects may take some time.
 
# ASCIIArt
The ASCIIArt project is a simple two frame animation of a cat dancing. This is a console project.\
To run this project, follow these steps:
1. Build the project:
 ```bash
 dotnet build
 ```
2. Run the project
  ```bash
 dotnet run
 ```

To finish running this animation, do:\
Windows:
```bash
 ctrl + C
````

Mac:
```bash
 control + C
````

# GUI
This project is a simple random colour generator. It involves pressing a button where a random colour will be generated, you are provided with the hexdemical of the colour as well.\
To run this project, follow these steps:
1. Build the project:
 ```bash
 dotnet build
 ```
2. Run the project
  ```bash
 dotnet run
 ```
 To close the application, click on the exit at the top of the window.
 
 # Tetris
 Tetris is the practical application, where you are able to play the game Tetris. Instead of blocks, we are using cats!\
 To run this project, follow these steps:
1. Build the project:
 ```bash
 dotnet build
 ```
2. Run the project
  ```bash
 dotnet run
 ```
 
 To close the application, click on the exit at the top of the window.

## Gameplay Instructions
The following are instructions on how to play the game:
- Left arrow: Move current block left.
- Right arrow: Move current block right.
- Down arrow: Move current block down.
- Up arrow: Rotate curent block clockwise.
- Z key: Rotate current block counter-clockwise.
- C key: Hold the current block.
- Left Shift key: hard drop the block.

Points are accumulated based on the number of rows that has been cleared.\
You are able to continute to play the game once to lose by pressing the purple "Play Again" button.

   
