using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Шлях до текстового файлу
        string filePath = @"C:\Users\foolm\OneDrive\Робочий стіл\input.txt";

        // Вивід вмісту текстового файлу зі зміненим порядком літер
        PrintReversedLines(filePath);
    }

    static void PrintReversedLines(string filePath)
    {
        // Перевіряємо, чи існує файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        try
        {
            // Читаємо текстовий файл
            string[] lines = File.ReadAllLines(filePath);

            // Проходимося по кожному рядку
            foreach (string line in lines)
            {
                // Використовуємо стек для зберігання літер рядка у зворотньому порядку
                Stack<char> stack = new Stack<char>();
                foreach (char c in line)
                {
                    stack.Push(c);
                }

                // Виводимо літери рядка у зворотньому порядку
                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop());
                }
                Console.WriteLine(); // Новий рядок після кожного рядка тексту
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
