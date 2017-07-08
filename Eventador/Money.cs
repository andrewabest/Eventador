using System.ComponentModel.DataAnnotations.Schema;

namespace Eventador
{
    [ComplexType]
    public class Money
    {
        public Money Create(decimal amount)
        {
            return new Money 
            {
                Amount = amount
            };
        }

        public decimal Amount { get; private set; }

        public string Currency => "AUD";

        public override bool Equals (object obj)
        {
            var money = obj as Money;
            
            if (money == null)
            {
                return false;
            }
            
            return this.Amount == money.Amount && this.Currency == money.Currency;
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}