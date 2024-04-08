// Hello C# Microsoft Lesson
Console.WriteLine("Hello World!");

string aFriend = "Bill";
Console.WriteLine("Hello " + aFriend);

aFriend = "Maira";
Console.WriteLine($"Hello {aFriend}");

string firstFriend = "Maira";
string secondFriend = "Sage";
Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");

string greeting = "      Hello World!     ";
Console.WriteLine($"[{greeting}]");

string trimmedGreeting = greeting.TrimStart();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.TrimEnd();
Console.WriteLine($"[{trimmedGreeting}]");

trimmedGreeting = greeting.Trim();
Console.WriteLine($"[{trimmedGreeting}]");

string sayHello = "Hello World!";
Console.WriteLine(sayHello);
sayHello = sayHello.Replace("Hello", "Greetings");
Console.WriteLine(sayHello);

Console.WriteLine(sayHello.ToUpper());
Console.WriteLine(sayHello.ToLower());

string songLyrics = "You say goodbye, and I say hello";
Console.WriteLine(songLyrics.Contains("goodbye"));
Console.WriteLine(songLyrics.Contains("greetings"));

// Challenge
Console.WriteLine(songLyrics.StartsWith("You"));
Console.WriteLine(songLyrics.StartsWith("goodbye"));
Console.WriteLine(songLyrics.EndsWith("hello"));
Console.WriteLine(songLyrics.EndsWith("goodbye"));

//----------------------------------------------------
// Manipulate integral and floating point numbers in C#
int a = 18;
int b = 6;
int c = a + b;
Console.WriteLine(c);

c = a - b;
Console.WriteLine(c);

c = a * b;
Console.WriteLine(c);

c = a / b;
Console.WriteLine(c);

a = 5;
b = 4;
c = 2;
int d = a + b * c;
Console.WriteLine(d);

d = (a + b) * c;
Console.WriteLine(d);

d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
Console.WriteLine(d);

// Rounds Down
d = (a + b) / c;
Console.WriteLine(d);

a = 7;
b = 4;
c = 3;
d = (a + b) / c;
int e = (a + b) % c;
Console.WriteLine($"quotient: {d}");
Console.WriteLine($"remainder: {e}");

int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is {min} to {max}");

int what = max + 3;
Console.WriteLine($"an example of overflow: {what}");

double x = 5;
double y = 4;
double z = 2;
double doub = (x + y) / z;
Console.WriteLine(doub);

x = 19;
y = 23;
c = 8;
doub = (x + y) / z;
Console.WriteLine(doub);

double maximum = double.MaxValue;
double minimum = double.MinValue;
Console.WriteLine($"The range of double is {minimum} to {maximum}");

double third = 1.0 / 3.0;
Console.WriteLine(third);

decimal mini = decimal.MinValue;
decimal maxi = decimal.MaxValue;
Console.WriteLine ($"The range of the decimal type is {mini} to {maxi}");

decimal w = 1.0M;
decimal u = 3.0M;
Console.WriteLine(w / u);

double radius = 2.5;
double area = Math.PI * radius * radius;
Console.WriteLine($"The area of the circle is {area}");

//----------------------------------------------------
// Branches and Loops in C#
a = 5;
b = 3;
if (a + b > 10)
{
    Console.WriteLine("The answer is greater than 10.");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
}

c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}

if ((a + b + c > 10) || (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}

int counter = 0;
// Tests the condition before executing the code
while (counter < 10)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
}

// Executes the code then checks the condition
int count = 0;
do
{
    Console.WriteLine($"Hello World! The count is {count}");
    count++;
} while (counter < 10);

for (int c0 = 0; c0 < 10; c0++)
{
    Console.WriteLine($"Hello World! The c0 is {c0}");
}

for (int row = 1; row < 11; row++)
{
    for (char column = 'a'; column < 'k'; column++)
    {
        Console.WriteLine ($"The cell is ({row}, {column})");
    }
}

int sum = 0;
for (int i = 1; i < 21; i++)
{
    if (i % 3 == 0)
    {
        sum = sum + i;
    }
}
Console.WriteLine(sum);

//----------------------------------------------------
// The list collection
var names = new List<string> {"Jeslyn", "Ana", "Felipe"};
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

Console.WriteLine($"My name is {names[0]}.");
Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");

Console.WriteLine($"The list has {names.Count} people in it.");

var index = names.IndexOf("Felipe");
if (index != -1)
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}
var notFound = names.IndexOf("Not Found");
Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

var fibonacciNumbers = new List<int> {1, 1};
var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);

foreach(var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}

Console.WriteLine();

while (fibonacciNumbers.Count < 20)
{
    previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
    fibonacciNumbers.Add(previous + previous2);
}
foreach(var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}
