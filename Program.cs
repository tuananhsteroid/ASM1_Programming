using System;

namespace WaterBillCalculator
{
    internal class Program
    {
        static void showfirstmenu()
        {
            Console.WriteLine("====================Menu====================");
            Console.WriteLine("\t1. Calculate water bill");
            Console.WriteLine("\t2. Exit");
        }

        static void showsecondmenu()
        {
            Console.WriteLine("______________Menu______________");
            Console.WriteLine("1. Household customer");
            Console.WriteLine("2. Administrative agency, public services");
            Console.WriteLine("3. Production units");
            Console.WriteLine("4. Business services");
            Console.WriteLine("5. Exit");
        }

        static string CustomerChoice()
        {
            Console.WriteLine("\nPlease choose the customer type:");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter again: ");
                choice = Console.ReadLine();
            }

            Console.Clear();
            return choice;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("If you enter anything other than 2, the program will default to off.");
            Console.Write("Do you want to start the program (yes/no): ");
            string select = Console.ReadLine();
            Console.Clear();

            while (select == "yes" )
            {
                showfirstmenu();

                Console.Write("\tEnter your choice:");
                string choice0 = Console.ReadLine();
                while (choice0 != "1" && choice0 != "2")
                {
                    Console.WriteLine("Invalid choice: ");
                    Console.Write("Enter again: ");
                    choice0 = Console.ReadLine();
                }
                Console.Clear();

                if (choice0 == "2")
                {
                    Console.WriteLine("Program closed.");
                    break;
                }

                showsecondmenu();
                string choice = CustomerChoice();

                if (choice == "5")
                {
                    Console.WriteLine("Program closed.");
                    break;
                }

                Console.WriteLine("===================== BILL =====================");

                double n = GetData();

                CalculateBill(choice, n);

                Console.WriteLine("\n-----------------------------------------------");

                if (select == "no")
                {
                    break;
                }
            }
        }

        static double GetData()
        {
            Console.Write("\nCustomer name:");
            string name = Console.ReadLine();

            double lastmonth, thismonth;
            Console.Write("\nLast month's water meter reading: ");
            while (!double.TryParse(Console.ReadLine(), out lastmonth))
            {
                Console.WriteLine("Error. Please enter again.");
                Console.Write("\nLast month's water meter reading: ");
            }

            Console.Write("\nThis month's water meter reading: ");
            while (!double.TryParse(Console.ReadLine(), out thismonth) || lastmonth > thismonth)
            {
                Console.WriteLine("Error. Please enter again.");
                Console.Write("\nThis month's water meter reading: ");
            }

            double m3 = thismonth - lastmonth;
            Console.WriteLine("\nWater used (m3): " + m3 + "m3");

            return m3;
        }

        static void CalculateBill(string choice, double m3)
        {
            switch (choice)
            {
                case "1":
                    {
                        Console.Write("\nNumber of household members: ");
                        int numberOfPeople;
                        while (!int.TryParse(Console.ReadLine(), out numberOfPeople))
                        {
                            Console.WriteLine("Error. Please enter again.");
                            Console.Write("Number of household members: ");
                        }
                        double cubicMetersPerPerson = m3 / numberOfPeople;

                        double totalAmount = 0;
                        double remainingCubicMeters = cubicMetersPerPerson;
                        double[] waterPrices = { 5.973, 7.052, 8.699, 15.929 };

                        for (int i = 0; i < 3 && remainingCubicMeters > 0; i++)
                        {
                            double currentCubicMeters = Math.Min(10, remainingCubicMeters);
                            totalAmount += currentCubicMeters * waterPrices[i];
                            remainingCubicMeters -= currentCubicMeters;
                        }

                        if (remainingCubicMeters > 0)
                        {
                            totalAmount += remainingCubicMeters * waterPrices[3];
                        }

                        double total = totalAmount * numberOfPeople;
                        double environmentalTax = total / 10;
                        double VAT = (total + environmentalTax) / 10;
                        double grandTotal = VAT + environmentalTax + total;

                        Console.WriteLine("\nAmount per person: " + totalAmount.ToString("0.000") + "VND");
                        Console.WriteLine("\nTotal amount for " + numberOfPeople + " people: " + total.ToString("#,#.000") + "VND");
                        Console.WriteLine("\nVAT amount: " + VAT.ToString("0.000") + " VND");
                        Console.WriteLine("\nEnvironmental tax amount: " + environmentalTax.ToString("0.000") + " VND");
                        Console.WriteLine("\nTotal payment after tax: " + grandTotal.ToString("#,#.000") + "VND");
                    }
                    break;

                case "2":
                    {
                        double total = m3 * 9.955;
                        double environmentalTax = total / 10;
                        double VAT = (total + environmentalTax) / 10;
                        double grandTotal = VAT + environmentalTax + total;

                        Console.WriteLine("Total amount before tax: " + total.ToString("0.000") + " VND");
                        Console.WriteLine("VAT amount: " + VAT.ToString("0.000") + " VND");
                        Console.WriteLine("Environmental tax amount: " + environmentalTax.ToString("0.000") + " VND");
                        Console.WriteLine("Total payment after tax: " + grandTotal.ToString("#,#.000") + "VND");
                    }
                    break;

                case "3":
                    {
                        double total = m3 * 11.615;
                        double environmentalTax = total / 10;
                        double VAT = (total + environmentalTax) / 10;
                        double grandTotal = VAT + environmentalTax + total;

                        Console.WriteLine("Total amount before tax: " + total.ToString("0.000") + " VND");
                        Console.WriteLine("VAT amount: " + VAT.ToString("0.000") + " VND");
                        Console.WriteLine("Environmental tax amount: " + environmentalTax.ToString("0.000") + " VND");
                        Console.WriteLine("Total payment after tax: " + grandTotal.ToString("#,#.000") + "VND");
                    }
                    break;

                case "4":
                    {
                        double total = m3 * 22.068;
                        double environmentalTax = total / 10;
                        double VAT = (total + environmentalTax) / 10;
                        double grandTotal = VAT + environmentalTax + total;

                        Console.WriteLine("Total amount before tax: " + total.ToString("0.000") + " VND");
                        Console.WriteLine("VAT amount: " + VAT.ToString("0.000") + " VND");
                        Console.WriteLine("Environmental tax amount: " + environmentalTax.ToString("0.000") + " VND");
                        Console.WriteLine("Total payment after tax: " + grandTotal.ToString("#,#.000") + "VND");
                    }
                    break;
            }
        }
    }
}

