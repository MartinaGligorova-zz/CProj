using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSProject
{
    public class PaySlip
    {
        private int month, year;

        // enumerated data type
        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
      
            string path;

            foreach (Staff f in myStaff)
            {
               
                path = f.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    // generating the pay slip for each employee
                    // cast month(int) to (MonthsOfYear data type i.e. 12 = DEC)
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear) month, year);
                    sw.WriteLine("===============================================");
                    // NameOfStaff accessed through Staff object
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    // print empty line here
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    // Line 7 e allowance - Manager type of obj. can access it
                    if (f.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {0:C}", ((Manager) f).Allowance);
                    else if (f.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime pay: {0:C}", ((Admin) f).Overtime);
                    sw.WriteLine("");
                    sw.WriteLine("===============================================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("===============================================");
                    sw.Close();
                }
            }
        }

        // generate summary of employees < 10hs month
        public void GenerateSummary(List<Staff> myStaff)
        {
            // we use LINQ to select all empl. < 10 hrs month
            // NameOfStaff & HoursWorked properties for each
            // + result in ascending order based on NamesOfStaff
            var result =
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new {staff.NameOfStaff, staff.HoursWorked};
            // new - to select more than one field from the objects

            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var staff in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", staff.NameOfStaff, staff.HoursWorked);
                }

                sw.Close();
            }
        }

        // fields &/or properties
        public override string ToString()
        {
            return "\nmonth =" + month + "\nyear = " + year;
        }
    }
}