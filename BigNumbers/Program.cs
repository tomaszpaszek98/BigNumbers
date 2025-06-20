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