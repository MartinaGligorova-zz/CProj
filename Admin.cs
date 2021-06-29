namespace CSProject
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;
        
        public float Overtime { get; private set; }
        
        public Admin(string name) : base(name, adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Overtime = overtimeRate * (HoursWorked - 160);
            if (HoursWorked > 160)
                TotalPay += Overtime;
        }

        public override string ToString()
        {
            return "\nOvertime Rate = " + overtimeRate + "\nAdmin Hourly Rate = " + adminHourlyRate + "\nOvertime = " +
                   Overtime;
        }
    }
}