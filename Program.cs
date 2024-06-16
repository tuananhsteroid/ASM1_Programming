using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asm1
{
    internal class Program
    {
        static void showfirstmenu()
        {
            Console.WriteLine("====================Menu====================");
            Console.WriteLine("\t1. Tinh hoa don tien nuoc");
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
            
            Console.WriteLine("\nVui long chon doi tuong thanh toan:");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Khong co lua nao nhu vay, Moi nhap lai: ");
                choice = Console.ReadLine();
            }
            
            Console.Clear();
            return choice;
            
        }


        static void Main(string[] args)
        {
            
            Console.WriteLine("Neu ban nhap khac 2 lua chon tren chuong trinh mac dinh tat");
            Console.Write("Ban co bat dau chuong trinh (co/khong): ");
            string select = Console.ReadLine();
            Console.Clear();
            while (select == "co")
            {
                
                showfirstmenu();
            
                    Console.Write("\tXin moi nhap lua chon:");
                    string choice0 = Console.ReadLine();
                    while (choice0 != "1" && choice0 != "2")
                    {
                        Console.WriteLine("Khong co lua nao nhu vay ");
                        Console.Write("Nhap lai: ");
                        choice0 = Console.ReadLine();
                    }
                    Console.Clear();
            
                    if (choice0 == "2")
                    {
                        Console.WriteLine("Chuong Trinh da dong");
                        break;
                    }

                    showsecondmenu();
                    string choice = CustomerChoice();

                    if (choice == "5")
                    {
                        Console.WriteLine("Chuong Trinh da dong");
                        break;
                    }

                    Console.WriteLine("===================== HOA DON =====================");

                    double n = solieu();

                    Caculator(choice, n);

                    Console.WriteLine("\n---------------------------------------------------------------------------------------------");

                if (select == "khong")
                {
                    break;
                }
            }
            
        }



        static double solieu()
        {
            

            Console.Write("\nTen khach hang:");
            string name = Console.ReadLine();

            double lastmonth, thismonth;
            Console.Write("\nChi so nuoc thang truoc: ");
            while (!double.TryParse(Console.ReadLine(), out lastmonth))
            {
                Console.WriteLine("Erorr. Xin moi nhap lai");
                Console.Write("\nChi so nuoc thang truoc: ");
            }

            Console.Write("\nChi so nuoc thang nay: ");
            while (!double.TryParse(Console.ReadLine(), out thismonth) || lastmonth > thismonth)
            {
                Console.WriteLine("Erorr. Xin moi nhap lai.");
                Console.Write("\nChi so nuoc thang nay: ");
            }

            double n = thismonth - lastmonth;
            Console.WriteLine("\nSo nuoc da dung (m3):" + n + "m3");

            return n;
        }



        static void Caculator(string choice, double n)
        {

            switch (choice)
            {

                case "1":
                    {
                        Console.Write("\nHo gia đinh có bao nhieu nguoi: ");
                        int soNguoi;
                        while (!int.TryParse(Console.ReadLine(), out soNguoi))
                        {
                            Console.WriteLine("Erorr. Xin vui long nhap lai.");
                            Console.Write("Ho gia đinh có bao nhieu nguoi: ");
                        }
                        double m3ng = n / soNguoi;

                        double tongTien = 0;
                        double soMetKhốiConLai = m3ng;
                        double[] giaNuoc = { 5.973, 7.052, 8.699, 15.929 };

                        for (int i = 0; i < 3 && soMetKhốiConLai > 0; i++)
                        {
                            double soMetKhốiHienTai = Math.Min(10, soMetKhốiConLai);
                            tongTien += soMetKhốiHienTai * giaNuoc[i];
                            soMetKhốiConLai -= soMetKhốiHienTai;
                        }

                        if (soMetKhốiConLai > 0)
                        {
                            tongTien += soMetKhốiConLai * giaNuoc[3];
                        }

                        
                        double total = tongTien * 5;
                        double tienThueMT = total / 10;
                        double tienThueVAT = (total + tienThueMT) / 10;
                        double tong = tienThueVAT + tienThueMT + total;

                        Console.WriteLine("\nSo tien moi nguoi la:" + tongTien.ToString("0.000") + "VND");
                        Console.WriteLine("\nTong tien cua " + soNguoi + " nguoi la:" + total.ToString("#,#.000") + "VND");
                        Console.WriteLine("\nSo tien thue VAT la: " + tienThueVAT.ToString("0.000") + " VND");
                        Console.WriteLine("\nSo tien thue moi truong la:" + tienThueMT.ToString("0.000") + " VND");
                        Console.WriteLine("\ntong phai thanh toan sau thue la:" + tong.ToString("#,#.000") + "VND");
                    }

                    break;


                case "2":
                    {
                        double total = n * 9.955;
                        double tienThueMT = total / 10;
                        double tienThueVAT = (total + tienThueMT) / 10;
                        double tong = tienThueVAT + tienThueMT + total;

                        Console.WriteLine("Tien truoc thue la:" + total.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue VAT la: " + tienThueVAT.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue moi truong la:" + tienThueMT.ToString("0.000") + " VND");
                        Console.WriteLine("tong phai thanh toan sau thue la:" + tong.ToString("#,#.000") + "VND");
                    }
                    break;

                case "3":
                    {
                        double total = n * 11.615;
                        double tienThueMT = total / 10;
                        double tienThueVAT = (total + tienThueMT) / 10;
                        double tong = tienThueVAT + tienThueMT + total;

                        Console.WriteLine("Tien truoc thue la:" + total.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue VAT la: " + tienThueVAT.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue moi truong la:" + tienThueMT.ToString("0.000") + " VND");
                        Console.WriteLine("tong phai thanh toan sau thue la:" + tong.ToString("#,#.000") + "VND");
                    }
                    break;

                case "4":
                    {
                        double total = n * 22.068;
                        double tienThueMT = total / 10;
                        double tienThueVAT = (total + tienThueMT) / 10;
                        double tong = tienThueVAT + tienThueMT + total;

                        Console.WriteLine("Tien truoc thue la:" + total.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue VAT la: " + tienThueVAT.ToString("0.000") + " VND");
                        Console.WriteLine("So tien thue moi truong la:" + tienThueMT.ToString("0.000") + " VND");
                        Console.WriteLine("tong phai thanh toan sau thue la:" + tong.ToString("#,#.000") + "VND");
                    }
                    break;

            }

        }
    }



}


