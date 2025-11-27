namespace RobotExplorerApp
{
    public class AerialRobot : RobotExplorer
    {
        // Дополнительное поле
        private int _flightAltitude;

        // Конструктор по умолчанию
        public AerialRobot() : base()
        {
            _flightAltitude = 500;
        }

        // Конструктор с параметрами
        public AerialRobot(string missionName, int protectionLevel, float powerReserve,
                         string terrainType, string manufacturer, int flightAltitude)
                         : base(missionName, protectionLevel, powerReserve, terrainType, manufacturer)
        {
            FlightAltitude = flightAltitude;
        }

        // Дополнительное свойство
        public int FlightAltitude
        {
            get { return _flightAltitude; }
            set
            {
                if (value <= 0 || value > 20000)
                    throw new ArgumentException("Высота полета должна быть от 1 до 20000 метров");
                _flightAltitude = value;
            }
        }

        // Переопределение метода

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Высота полета: {FlightAltitude} м");
            Console.WriteLine("Тип: Воздушный робот");
        }

        public override void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"Тип: Воздушный робот");
                    writer.WriteLine($"Миссия: {MissionName}");
                    writer.WriteLine($"Уровень защиты: {ProtectionLevel}");
                    writer.WriteLine($"Запас хода: {PowerReserve}");
                    writer.WriteLine($"Местность: {TerrainType}");
                    writer.WriteLine($"Производитель: {Manufacturer}");
                    writer.WriteLine($"Высота полета: {FlightAltitude}м");
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