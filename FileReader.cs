using System;
using System.Collections.Generic;
using System.IO;

namespace CSProject
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = {", "};

            if (File.Exists(path))
            {
                try
                {
                    // An instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.EndOfStream != true)
                        {
                     
                            result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                            if (result[1].Equals("Manager"))
                                myStaff.Add(new Manager(result[0]));
                            else if (result[1].Equals("Admin"))
                                myStaff.Add(new Admin(result[0]));
                            else
                                Console.WriteLine("The position is neither Admin nor Manager - error");
                        }

                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return myStaff;
            // the methods returns a list of Staff obj.
        }
    }
}