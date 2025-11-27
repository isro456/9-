using System;
using RobotExplorerApp;

namespace RobotExplorerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ДЕМОНСТРАЦИЯ ИЕРАРХИИ КЛАССОВ РОБОТОВ-ИССЛЕДОВАТЕЛЕЙ\n");

            // Создание массива базового типа с 4 элементами
            RobotExplorer[] robots = new RobotExplorer[4];

            // Создание экземпляров разных классов
            robots[0] = new PlanetRover("Марс-2024", 8, 150.5f, "Пустыня", "NASA", 3);
            robots[1] = new DeepWaterRobot("Тихий океан", 9, 80.2f, "Океан", "OceanTech", 4000);
            robots[2] = new AerialRobot("Картография", 5, 200.0f, "Горы", "SkyDrones", 1500);
            robots[3] = new PlanetRover("Луна-эксплорер", 7, 120.0f, "Пустыня", "Роскосмос", 1);

            // Демонстрация конструкторов
            Console.WriteLine("1. СОЗДАННЫЕ РОБОТЫ:");
            for (int i = 0; i < robots.Length; i++)
            {
                Console.WriteLine($"\nРобот #{i + 1}:");
                robots[i].DisplayInfo();

            }

            // Демонстрация операторов сравнения
            Console.WriteLine("\n2. СРАВНЕНИЕ ПО УРОВНЮ ЗАЩИТЫ:");
            Console.WriteLine($"Робот 1 > Робот 2: {robots[0] > robots[1]}");
            Console.WriteLine($"Робот 1 < Робот 3: {robots[0] < robots[2]}");

            // Демонстрация изменения данных
            Console.WriteLine("\n3. ИЗМЕНЕНИЕ ДАННЫХ:");
            try
            {
                robots[0].UpdateInfo("Марс-2025", 9, 180.0f, "Пустыня", "NASA+ESA");
                Console.WriteLine("Данные успешно обновлены:");
                robots[0].DisplayInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении: {ex.Message}");
            }

            // Демонстрация обработки ошибок
            Console.WriteLine("\n4. ПРОВЕРКА ВАЛИДАЦИИ:");
            try
            {
                robots[1].ProtectionLevel = 15; // Неверное значение
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Сохранение в файл
            Console.WriteLine("\n5. СОХРАНЕНИЕ В ФАЙЛ:");
            string filename = "robots.txt";
            foreach (var robot in robots)
            {
                robot.SaveToFile(filename);
            }
            Console.WriteLine($"Все данные сохранены в файл: {filename}");

            Console.WriteLine("\n Демонстрация завершена!");
        }
    }
}