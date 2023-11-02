namespace PPOIS3
{
    public class ClientDiscount
    {
        private double value;
        public double Value
        {
            get => value;
            set
            {
                if (value <= 0 || value >= 1)
                    throw new ArgumentOutOfRangeException(nameof(value));
                this.value = value;
            }
        }
        public ClientDiscount(double value) => Value = value;

        public virtual double Apply(Basket basket) => Value * basket.Price;

        public override string ToString() => Value.ToString();
    }
}
