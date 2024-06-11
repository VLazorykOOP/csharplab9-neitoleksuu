using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Шлях до текстового файлу
        string filePath = @"C:\Users\foolm\OneDrive\Робочий стіл\input.txt";

        // Вивід елементів файлу в потрібному порядку
        PrintWordsByStartingLetter(filePath);
    }

    static void PrintWordsByStartingLetter(string filePath)
    {
        // Перевіряємо, чи існує файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        try
        {
            // Читаємо текстовий файл та розділяємо його на слова
            string[] words = File.ReadAllText(filePath).Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Створюємо чергу для голосних та приголосних слів
            Queue<string> vowelWords = new Queue<string>();
            Queue<string> consonantWords = new Queue<string>();

            // Розділяємо слова за початковою літерою
            foreach (string word in words)
            {
                // Перевіряємо, чи починається слово на голосну букву
                if (IsVowel(word[0]))
                {
                    vowelWords.Enqueue(word);
                }
                else
                {
                    consonantWords.Enqueue(word);
                }
            }

            // Виводимо голосні слова
            Console.WriteLine("Слова, які починаються на голосну букву:");
            PrintQueue(vowelWords);

            // Виводимо приголосні слова
            Console.WriteLine("\nСлова, які починаються на приголосну букву:");
            PrintQueue(consonantWords);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    // Метод для перевірки, чи є літера голосною
    static bool IsVowel(char letter)
    {
        string vowels = "аеєиіїоуюяaeiouyAEIOUYаеєиіїоуюя";
        return vowels.Contains(letter);
    }

    // Метод для виведення елементів черги на екран
    static void PrintQueue(Queue<string> queue)
    {
        foreach (string item in queue)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
