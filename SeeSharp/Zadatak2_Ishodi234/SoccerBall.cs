namespace Zadatak2_Ishodi234
{

    enum BallSize
    {
        Four, Five
    }

    class SoccerBall : Product
    {
        public BallSize Size { get; set; }

        public SoccerBall(int id, string name, float price, BallSize size) : base(id, name, price)
        {
            Size = size;
        }

        public override string ToString()
        {
            return base.ToString() + $"Ball size: {Size} {System.Environment.NewLine}";
        }
    }
}
