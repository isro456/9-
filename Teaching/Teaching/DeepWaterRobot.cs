namespace RobotExplorerApp
{
    public class DeepWaterRobot : RobotExplorer
    {
        // Дополнительное поле
        private int _maxDepth;

        // Конструктор по умолчанию
        public DeepWaterRobot() : base()
        {
            _maxDepth = 1000;
        }

        // Конструктор с параметрами
        public DeepWaterRobot(string missionName, int protectionLevel, float powerReserve,
                            string terrainType, string manufacturer, int maxDepth)
                            : base(missionName, protectionLevel, powerReserve, terrainType, manufacturer)
        {
            MaxDepth = maxDepth;
        }

        // Дополнительное свойство
        public int MaxDepth
        {
            get { return _maxDepth; }
            set
            {
                if (value <= 0 || value > 11000)
                    throw new ArgumentException("Максимальная глубина должна быть от 1 до 11000 метров");
                _maxDepth = value;
            }
        }

        // Переопределение метода

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Максимальная глубина: {MaxDepth} м");
            Console.WriteLine("Тип: Глубоководный робот");
        }

        public override void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Тип: Глубоководный робот");
                    writer.WriteLine($"Миссия: {MissionName}");
                    writer.WriteLine($"Уровень защиты: {ProtectionLevel}");
                    writer.WriteLine($"Запас хода: {PowerReserve}");
                    writer.WriteLine($"Местность: {TerrainType}");
                    writer.WriteLine($"Производитель: {Manufacturer}");
                    writer.WriteLine($"Макс. глубина: {MaxDepth}м");
                    writer.WriteLine("---");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}