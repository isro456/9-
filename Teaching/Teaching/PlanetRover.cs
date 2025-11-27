namespace RobotExplorerApp
{
    class PlanetRover: RobotExplorer
    {
        private int _planetGravity;

        public PlanetRover() : base()
        {
            _planetGravity = 1;
        }
        public PlanetRover(string missionName, int protectionLevel, float powerReserve, string terrainType, string manufacturer,int _PlanetGravity) : base(missionName, protectionLevel, powerReserve, terrainType, manufacturer)
        {
              _PlanetGravity = _planetGravity;
        }

        public int GravityInfo
        {
            get { return _planetGravity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("АЛЕ ТЫ КУДА ПРЕШЬ");
                }
                _planetGravity = value;
            }
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Гравитация планеты: {_planetGravity}g");
            Console.WriteLine("Тип: Планетаход");
        }
    }
}