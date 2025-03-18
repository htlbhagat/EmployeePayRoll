using System;
using System.IO;

namespace ExersicePerson
{
    struct Employee
        // to encapsulate employees details in a single data structure 
    {
        public int employeeId;
        public string employeeFirstName;
        public string employeeLastName;
        public int annualIncome;
        public double kiwiSaver;
        public double annualTax;
        public double netPay;
        public double fortnightlyPay;
        public decimal hourlyWage;    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Create an array named employees and initialize it using the ReadEmployeeDetails function.
            Employee[] employees = ReadEmployeeDetails("employees_details.txt");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Author : HETAL BHAGAT"); // Authers name is displayed on console
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("***** KIWI GARAGE EMPLOYEE RECORDS *****"); // Programme name is displayed on console 
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("== Select an option from below menu ==");
                Console.WriteLine();
                Console.WriteLine("1. Fortnight payroll calculation");
                Console.WriteLine("2. Sort and display the employee records");
                Console.WriteLine("3. Search for an employee");
                Console.WriteLine("4. Save into a text file");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                // Create a Menu to display diffrent options, and take user input of choice
                // Taking user input- choice as a string and Verifying if the user input-choice can be outputed into int 
                // If user input is invalid than display message on console prompting user to slecet an option for given menu 
                
                int choice = 0;
                string userChoice = (Console.ReadLine());
                if (int.TryParse(userChoice, out int parsedInt))
                {
                    choice = parsedInt;
                }
                else
                {
                    choice = -1;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        FortnightPayrollCalculation(employees); // this method will calculate forthnightly pay roll for an emploee
                        break;
                    case 2:
                        SortAndDisplayTheEmployeeRecords(employees);// this method will display employees records in an asending order by their ID 
                        break;
                    case 3:
                        SearchForAnEmployee(employees);// this method will display search result 
                        break;
                    case 4:
                        SaveInToATextFile(employees);// file is created to store data of new kiwi garage employees payroll 
                        Console.WriteLine("Successfully saved");
                        break;
                    case 0:
                        exit = true;//when press 0 user will be existed from the programme 
                        break;
                    default:
                        Console.WriteLine("Invalid option number. Please choose from the following options:");
                        break;
                }
            }
        }

        // Sort Employee Records by their ID
        // Sorted employees records will be displayed on console 
        private static void SortAndDisplayTheEmployeeRecords(Employee[] employees)
        {
            // Implement sorting and displaying functionality
            for (int i = 0; i <= employees.Length; i++)
            {
                for (int j = 0; j < employees.Length - i - 1; j++)
                {
                    if (employees[j].employeeId > employees[j + 1].employeeId)
                    {
                        Employee temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;
                    }
                }
            }
            DisplayEmployees(employees);
        }


        // To caluculate forthnightly payroll for all employees 
        // this functions also calculate employees kiwisaveer calculation and their net pay after tax on forthnightly basis 
        private static void FortnightPayrollCalculation(Employee[] employees)
        {
 

            for (int i = 0; i < employees.Length ; i++)
            {
                // Calclulating Kiwi Saver
                double ks = 0;
                int annualInc = 0;
                annualInc = employees[i].annualIncome;
                ks = employees[i].kiwiSaver;
                ks = annualInc * ks;
                ks = Math.Round(ks, 2);

                // Calculating Tax on Annual Income
                double tax = 0;
                //double tax1 = 0;
                //double tax2 = 0;
                //double tax3 = 0;
                //double tax4 = 0;
                //double tax5 = 0;
                if (annualInc <= 14000) //tax calculation on an Annual income of an employee upto 14000
                {
                    double taxRate = 0.105;
                    tax = (annualInc * taxRate);
                }
                else if (annualInc  > 14000 && annualInc <= 48000) // tax calculation on an Annual income of morethan 14000 and upto 48000
                {
                    // tax on first 14000
                    double taxRate = 0.105;
                    int taxableIncome = 14000;
                    
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 14000 up to 48000
                    taxableIncome = annualInc - 14000;
                    taxRate = 0.175;
                    //tax2 = 0;
                    tax = tax + (taxableIncome * taxRate);
                }
                else if (annualInc > 48000 && annualInc <= 70000) // tax calculation on an Annual income of morethan 48000 and upto 70000
                {
                    // tax on first 14000
                    double taxRate = 0.105;
                    int taxableIncome = 14000;
                    tax = tax + (taxableIncome * taxRate);
                    
                    // tax on amount more than 14000 up to 48000
                    taxableIncome = 34000;
                    taxRate = 0.175;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 48000 up to 70000
                    taxableIncome = annualInc - 48000;
                    taxRate = 0.30;
                    tax = tax + (taxableIncome * taxRate);
                }
                else if (annualInc > 70000 && annualInc <= 180000)// tax calculation on an Annual income of morethan 70000 and upto 180000
                {
                    // tax on first 14000
                    double taxRate = 0.105;
                    int taxableIncome = 14000;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 14000 up to 48000
                    taxableIncome = 34000;
                    taxRate = 0.175;
                    tax = tax +  (taxableIncome * taxRate);

                    // tax on amount more than 48000 up to 70000
                    taxableIncome = 22000;
                    taxRate = 0.30;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 70000 up to 180000
                    taxableIncome = annualInc - 180000;
                    taxRate = 0.33;
                    tax = tax + (taxableIncome * taxRate);

                }
                else if (annualInc > 180000) // tax calculation on an Annual income of morethan 180000 
                {
                    // tax on first 14000
                    double taxRate = 0.105;
                    int taxableIncome = 14000;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 14000 up to 48000
                    taxableIncome = 34000;
                    taxRate = 0.175;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 48000 up to 70000
                    taxableIncome = 22000;
                    taxRate = 0.30;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 70000 up to 180000
                    taxableIncome = 110000;
                    taxRate = 0.33;
                    tax = tax + (taxableIncome * taxRate);

                    // tax on amount more than 180000
                    taxableIncome = annualInc - 180000;
                    taxRate = 0.39;
                    tax = tax + (taxableIncome * taxRate);
                }

                employees[i].annualTax = tax;
                employees[i].annualTax = Math.Round(employees[i].annualTax, 2);

                employees[i].netPay = (annualInc - ks);
                employees[i].netPay = (employees[i].netPay - tax);
                employees[i].netPay = Math.Round(employees[i].netPay, 2);

                employees[i].hourlyWage = (employees[i].annualIncome / 40);
                employees[i].hourlyWage = (employees[i].hourlyWage / 52);
                employees[i].hourlyWage = Math.Round(employees[i].hourlyWage, 2) ;

                employees[i].fortnightlyPay = (employees[i].netPay / 52) * 2;
                employees[i].fortnightlyPay = Math.Round(employees[i].fortnightlyPay, 2);

              

            }
            // Display employees records and display their records on console 

            DisplayEmployees(employees);
        }

        // Function for reading the employee details
        // and populate employees arrey from the data file on to console 

        static Employee[] ReadEmployeeDetails(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Employee[] employees = new Employee[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                Employee employee = new Employee
                {
                    employeeId = int.Parse(parts[0]),
                    employeeFirstName = parts[1],
                    employeeLastName = parts[2],
                    annualIncome = int.Parse(parts[3]),
                    kiwiSaver = double.Parse(parts[4])
                };
                employees[i] = employee;
            }

            return employees;
        }

        // reading input from user 
        // Search function- searching for an employee record  by their ID
        // Display search result on the console with found emaplyee record
        // if employee record not found than display employee ID not found 
        static void SearchForAnEmployee(Employee[] employees)
        {
            Console.Write("Enter employee ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //foreach (var employee in employees)
            //{
            //    if (employee.employeeId == id)
            //    {
            //        Console.WriteLine("ID\tFirst Name\tLast Name\tAnnual Salary\tKiwi Saver");
            //        Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t\t{4}",
            //            employee.employeeId, employee.employeeFirstName, employee.employeeLastName,
            //            employee.annualIncome, employee.kiwiSaver);
            //        return;
            //    }
            //}

            for (int i = 0; i < employees.Length; i++)        
            {
                if (employees[i].employeeId == id)
                {

                    //            Console.WriteLine(String.Format("{0,-12} {1,-15} {2,-15} {3,-15} {4,-12} {5,-12} {6,-15}",
                    //"EmployeeID", "First Name", "Last Name", "Annual Income", "Kiwi Saver", "Annual Tax", "Fortnightly Pay"));


                    //            {
                    //                Console.WriteLine("{0,-12} {1,-15} {2,-15} {3,-15:C} {4,-12} {5,-12:C} {6,-15:C}",
                    //                    employees[i].employeeId, employees[i].employeeFirstName, employees[i].employeeLastName,
                    //                    employees[i].annualIncome, employees[i].kiwiSaver, employees[i].annualTax, employees[i].fortnightlyPay);
                    //            }
                    Console.WriteLine(String.Format("{0,-12} {1,-15} {2,-15} {3,-15} {4,-12} {5,-12} {6,-15} {7,-15}", // formater Header to align display of all columns and make it more readable 
        "EmployeeID", "First Name", "Last Name", "Annual Income", "Kiwi Saver", "Annual Tax", "Hourly Wage", "Fortnightly Pay"));

                    Console.WriteLine("{0,-12} {1,-15} {2,-15} {3,-15:C} {4,-12:P} {5,-12:C} {6,-15:C} {7,-15:C}",// display each employee records /formated object annual income, annual tax and fortnightlypay as a currency  
                    employees[i].employeeId, employees[i].employeeFirstName, employees[i].employeeLastName,
                    employees[i].annualIncome, employees[i].kiwiSaver, employees[i].annualTax, employees[i].hourlyWage, employees[i].fortnightlyPay);

                    return;
                }

            }
    

            Console.WriteLine("Employee with ID {0} not found.", id);
        }


        // Display Employee Records
        static void DisplayEmployees(Employee[] employees)
        {
            //Console.WriteLine(String.Format("EmployeeID\tFirst Name\tLast Name\tAnnual Income\tKiwi Saver\tAnnual Tax\tFortnightly Pay"));
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t\t{4}\t\t{5}\t\t{6}",
            //        employee.employeeId, employee.employeeFirstName, employee.employeeLastName, employee.annualIncome, employee.kiwiSaver, employee.annualTax, employee.fortnightlyPay);
            //}

            // To formate the table of an employee records, so that it aligns better and user have a good readability 
            Console.WriteLine(String.Format("{0,-12} {1,-15} {2,-15} {3,-15} {4,-12} {5,-12} {6,-15} {7,-15}", // formater Header to align display of all columns and make it more readable 
        "EmployeeID", "First Name", "Last Name", "Annual Income", "Kiwi Saver", "Annual Tax","Hourly Wage", "Fortnightly Pay"));

            foreach (var employee in employees) //iterating through to the employee record in an array 
            {
                Console.WriteLine("{0,-12} {1,-15} {2,-15} {3,-15:C} {4,-12:P} {5,-12:C} {6,-15:C} {7,-15:C}",// display each employee records /formated object annual income, annual tax and fortnightlypay as a currency  
                    employee.employeeId, employee.employeeFirstName, employee.employeeLastName,
                    employee.annualIncome, employee.kiwiSaver, employee.annualTax, employee.hourlyWage, employee.fortnightlyPay);
            }



            //for (int i = 0; i < employees.Length ; i++)
            //{
            //    Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t\t{4}\t\t{5}\t\t{6}",
            //       employees[i].employeeId,
            //       employees[i].employeeFirstName,
            //       employees[i].employeeLastName,
            //       employees[i].annualIncome,
            //       employees[i].kiwiSaver,
            //       employees[i].annualTax,
            //       employees[i].fortnightlyPay);
            //}
        }

        // Save into a text file
        // saved data into text file in a formate
        // data will be exported into text file
        
        static void SaveInToATextFile(Employee[] employees)
        {
            using StreamWriter writer = new StreamWriter("fornightly_payroll.txt");
            writer.WriteLine("Employee Id,First Name,Last Name,Annual Income,Kiwi Saver,Annual Tax,Hourly Wage,Forthnightly pay");
            //foreach (var employee in employees)
            //{
            //    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
            //        employee.employeeId, employee.employeeFirstName, employee.employeeLastName,
            //        employee.annualIncome, employee.kiwiSaver, employee.annualTax, employee.fortnightlyPay);
            //}
            for (int i = 0; i < employees.Length; i++) 
            {
                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}",
                    employees[i].employeeId, employees[i].employeeFirstName, employees[i].employeeLastName,
                    employees[i].annualIncome, employees[i].kiwiSaver, employees[i].annualTax, employees[i].hourlyWage, employees[i].fortnightlyPay);
            }

        }
    }
}
