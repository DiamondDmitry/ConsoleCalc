using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Calculator
{
    public double FirstNumber {  get; set; }
    public double SecondNumber { get; set; }
    public byte PositionNumber {  get; set; }
    
    //Метод получения числа из консоли
    public double GetNumber(byte PositionNumber)
    {
        double number;
        switch (PositionNumber)
        {
            case 1:
            Console.WriteLine("Введите первое число: ");
                break;

            case 2:
            Console.WriteLine("Введите второе число: ");
                break;
        }

        string numberStr;
        do
        {
            numberStr = Console.ReadLine();
            numberStr = numberStr.Replace(",", ".");
            while (!double.TryParse(numberStr, out number))
            {
                Console.WriteLine("Вы ввели некорректное число, повторите ввод: ");
                break;
            }
        } 
        while (!double.TryParse(numberStr, out number));

        return number;
    }
    //Метод сложение
    public double Addition(double firstNumber, double secondNumber)
    {
        double roundNumber = Math.Round(firstNumber + secondNumber, 12);
        return roundNumber;
    }

    //Метод вычитание
    public double Subtraction(double firstNumber, double secondNumber)
    {
        double roundNumber = Math.Round(firstNumber - secondNumber, 12);
        return roundNumber;
    }

    //Метод умножение
    public double Multiplication (double firstNumber, double secondNumber)
    {
        double roundNumber = Math.Round(firstNumber * secondNumber, 12);
        return roundNumber;
    }

    //Метод деление
    public double Division(double firstNumber, double secondNumber)
    {
        double roundNumber = Math.Round(firstNumber / secondNumber, 12);
        return roundNumber;
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("Калькулятор:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Выход");

            Console.Write("Выберите операцию (1/2/3/4/5): ");
            while (loop)
            {
                byte arithmetic;
                byte.TryParse(Console.ReadLine(), out arithmetic);
                Console.WriteLine(arithmetic);

                double number1, number2;
                Calculator Calculator1 = new Calculator();

                switch (arithmetic)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Операция сложения");
                        number1 = Calculator1.GetNumber(1);
                        number2 = Calculator1.GetNumber(2);
                        double resaultAddition = Calculator1.Addition(number1, number2);
                        Console.WriteLine("Результат сложения: " + resaultAddition + "\n");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Операция вычитания");
                        number1 = Calculator1.GetNumber(1);
                        number2 = Calculator1.GetNumber(2);
                        double resaultSubtraction = Calculator1.Subtraction(number1, number2);
                        Console.WriteLine("Результат вычитания: " + resaultSubtraction + "\n");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Операция умножения");
                        number1 = Calculator1.GetNumber(1);
                        number2 = Calculator1.GetNumber(2);
                        double resaultMultiplication = Calculator1.Multiplication(number1, number2);
                        Console.WriteLine("Результат умножения: " + resaultMultiplication + "\n");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Операция деления");
                        number1 = Calculator1.GetNumber(1);
                        number2 = Calculator1.GetNumber(2);
                        if(number2 == 0) 
                        {
                            Console.WriteLine("На ноль делить нельзя\n");
                            break; 
                        }
                        double resaultDivision = Calculator1.Division(number1, number2);
                        Console.WriteLine("Результат деления: " + resaultDivision + "\n");
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Спасмбо за использование нашего продукта, досвидания!");
                        loop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введено некорректное значение, повторите выбор");
                        break;
                }
                break;
            }
        }
    }
}