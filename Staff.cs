using System;

namespace CSProject
{
    //  info. about every employee/calculate pay of employees

    public class Staff
    {
        private float hourlyRate;
        private int hWorked;
        
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get { return hWorked; }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            // set value of property - private setter
            NameOfStaff = name;
            hourlyRate = rate;
        }

        // polymorph. virtual - method overriden in child classes 
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            // values of fields & properties
            return "\nHourly Rate = " + hourlyRate + "\nHours Worked = " + HoursWorked + "\nTotal Pay = " + TotalPay +
                   "\nBasic Pay = " + BasicPay + "\nName Of Staff = " + NameOfStaff;
        }
    }
}