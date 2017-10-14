namespace Zadatak2_Ishodi234
{

    enum RacketType
    {
        Tennis, Badminton
    }

    class Racket : Product
    {
        public int WireTension { get; set; }
        public RacketType Type { get; set; }

        public Racket(int id, string name, float price, int wireTension, RacketType type) : base(id, name, price)
        {
            WireTension = wireTension;
            Type = type;
        }

        public override string ToString()
        {
            return base.ToString() + $"Wire tension: {WireTension} kg; Sport: {Type} {System.Environment.NewLine}";
        }
    }
}
