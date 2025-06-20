# BigNumbers

This project provides a simple implementation of arithmetic operations (addition, subtraction, multiplication) for big numbers that exceed the limits of standard numeric types. It is designed to work only with natural numbers (non-negative integers).
Initially this project was created as a solution for exercise from book "[Zrozumieć Programowanie](https://zrozumiecprogramowanie.pl/#/mainPage)" wrote by Gynvael Coldwind but I decided to share with this project with you. :)

## Features

- Supports addition, subtraction, and multiplication for large natural numbers
- Handles numbers larger than built-in numeric types
- Simple and easy-to-understand implementation

## Usage Example

You can find an example of how to use this library in `Program.cs`. Typically, you would:

1. Create instances of the `BigNumber` class from various numeric collections or from a string using the `ToBigNumber()` extension methods.
2. Perform arithmetic operations using overloaded operators (`+`, `-`, `*`).

```csharp
using BigNumbers.Extensions;

var listNumber0 = new List<byte> { 1, 5 };
var bigNumber0 = listNumber0.ToBigNumber();

var listNumber1 = new List<short> { 1, 2, 3, 4, 5 };
var bigNumber1 = listNumber1.ToBigNumber();

var listNumber2 = new List<int> { 6, 7, 8, 9 };
var bigNumber2 = listNumber2.ToBigNumber();

var listNumber3 = new List<sbyte> { 2, 5, 5 };
var bigNumber3 = listNumber3.ToBigNumber();

var stringNumber = "1234567890123456789012345678901234567890";
var bigNumberFromString = stringNumber.ToBigNumber();

Console.WriteLine($"number1: {bigNumber1}");
Console.WriteLine($"number2: {bigNumber2}");

var number3 = bigNumber1 + bigNumber2;
Console.WriteLine($"{bigNumber1} + {bigNumber2} = {number3}");

var number4 = number3 - bigNumber2;
Console.WriteLine($"{number3} - {bigNumber2} = {number4}");

var number5 = number3 * bigNumber0;
Console.WriteLine($"{number3} * {bigNumber0} = {number5}");

var number6 = bigNumberFromString * bigNumber0;
Console.WriteLine($"{bigNumberFromString} * {bigNumber0} = {number6}");

var number7 = bigNumber3 * bigNumber0 + bigNumber1;
Console.WriteLine($"{bigNumber3} * {bigNumber0} + {bigNumber1} = {number7}");
```
## Main Components

- **BigNumber**: The core reference type representing large natural numbers.
- **ArithmeticOperations**: Directory containing the implementations of arithmetic operations.

## Note

This project is intended for educational purposes and demonstrates basic handling of big numbers. It does not support negative numbers or floating-point operations.
