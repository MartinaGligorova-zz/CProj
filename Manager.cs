namespace CSProject
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }
        
        public Manager(string name) : base(name, managerHourlyRate)
        {
        }
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            // TotalPay - derived classes have access 
            if (HoursWorked > 160)
                // add the allowance to it
                TotalPay += Allowance;
        }

        public override string ToString()
        {
            return "\nManager Hourly Rate = " + managerHourlyRate + "\nAllowance = " + Allowance;
        }
    }
}