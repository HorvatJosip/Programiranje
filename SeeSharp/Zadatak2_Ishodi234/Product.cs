namespace Zadatak2_Ishodi234
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public Product(int id, string name, float price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} ({Price} USD) [ID: {ID}] {System.Environment.NewLine}";
        }
    }
}
