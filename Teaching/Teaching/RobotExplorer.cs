using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;

namespace RobotExplorerApp
{
    public class RobotExplorer
    {
        // Закрытые поля
        private string _missionName;
        private int _protectionLevel;
        private float _powerReserve;
        private string _terrainType;

        // Общее поле для всех производных классов
        protected string _manufacturer;

        // Конструктор по умолчанию
        public RobotExplorer()
        {
            _missionName = "Неизвестная миссия";
            _protectionLevel = 1;
            _powerReserve = 10.0f;
            _terrainType = "Пустыня";
            _manufacturer = "РобоИндустрия";
        }

        // Конструктор с параметрами
        public RobotExplorer(string missionName, int protectionLevel, float powerReserve, string terrainType, string manufacturer)
        {
            MissionName = missionName;
            ProtectionLevel = protectionLevel;
            PowerReserve = powerReserve;
            TerrainType = terrainType;
            Manufacturer = manufacturer;
        }
        public string MissionName
        {
            get { return _missionName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Оно не может быть пустым, алье");
                }
                _missionName = value;
            }
        }
        public int ProtectionLevel
        {
            get { return _protectionLevel; }
            set
            {
                if (_protectionLevel >= 1 && _protectionLevel <= 10)
                {
                    throw new ArgumentOutOfRangeException("Уровень защиты может быть от 1 до 10 включительно");
                }
                _protectionLevel = value;
            }
        }
        public float PowerReserve
        {
            get { return _powerReserve; }
            set
            {
                if (PowerReserve < 0)
                {
                    throw new ArgumentOutOfRangeException("Запас хода больше быть положительным числом");
                }
                _powerReserve = value;
            }
        }
        public string TerrainType
        {
            get { return _terrainType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Не может оно быть пустым ебанный насрал");
                }
                _terrainType = value;

            }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Прозводитель не может быть пустотой");
                }
                _manufacturer = value;
            }
        }
        // Метод для просмотра информации
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Миссия {MissionName}");
            Console.WriteLine($"Уровень защиты: {_protectionLevel}");
            Console.WriteLine($"Запас хода: {PowerReserve}");
            Console.WriteLine($"Тип местности: {TerrainType}");
            Console.WriteLine($"Производитель: {Manufacturer}");
        }
        // Метод для изменения данных
        public virtual void UpdateInfo(string missionname, int protectionlevel, float powerReserve, string terrainType, string manufactures)
        {
            MissionName = missionname;
            ProtectionLevel = protectionlevel;
            PowerReserve = powerReserve;
            TerrainType = terrainType;
            Manufacturer = manufactures;
        }
        // Метод для сохранения в файл
        public virtual void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine($"Тип: Базовый робот");
                writer.WriteLine($"Миссия: {MissionName}");
                writer.WriteLine($"Уровень защиты: {ProtectionLevel}");
                writer.WriteLine($"Запас хода: {PowerReserve}");
                writer.WriteLine($"Местность: {TerrainType}");
                writer.WriteLine($"Производитель: {Manufacturer}");
                writer.WriteLine("---");
            }
        }
        public static bool operator <(RobotExplorer robot1, RobotExplorer robot2)
        {
            return robot1.ProtectionLevel < robot2.ProtectionLevel;
        }

        public static bool operator >(RobotExplorer robot1, RobotExplorer robot2)
        {
            return robot1.ProtectionLevel > robot2.ProtectionLevel;
        }
    }
}