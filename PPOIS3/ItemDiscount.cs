namespace PPOIS3
{   
    public class ItemDiscount
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
        public ItemDiscount(double value) => Value = value;
        public virtual double Apply(Item item) => Value * item.Price * item.Number;
        public override string ToString() => Value.ToString();
    }
}
