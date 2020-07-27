using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PassList
{
    class Program
    {
        static int lengths = 4;
        static char[] chars;
        static int fact = 1;
        static System.Collections.ArrayList List = new System.Collections.ArrayList();
        static void Main(string[] args)
        {
            Console.Title = "GuardIran Pass List Maker";
            Console.WriteLine("::: Hello this app developed by Mr. Touraj Ostovari for creating pass list :::\nEnter your chars: ");
            chars = (Console.ReadLine().ToCharArray());
            Console.WriteLine("Enter your goal length - Default length is 4");
            lengths = int.Parse(Console.ReadLine().ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = (chars.Length); i > 1; i--)
            {
                fact *= i;
            }

            Console.WriteLine("Total Possible Passwords {0}", fact);


            System.Threading.Thread th1 = new System.Threading.Thread(Generator);
            

            th1.Start();
            th1.Join();
            //Thread.CurrentThread.Join();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to exit ...");
            Console.ReadLine();
        }
        static void Generator()
        {
            //Thread.CurrentThread.IsBackground = true;
            int condition = 0;
            string temp = "";
            Int64 counter = 0;
            while (true)
            {
                for (int i = 0; i < lengths; i++)
                {
                    Random random = new Random();
                    Int64 ids = random.Next(0, chars.Length - 1);
                    temp += chars[ids].ToString();
                }
                if (!List.Contains(temp))
                {
                    List.Add(temp);
                    using (System.IO.FileStream fileStream = new FileStream(@"C:\pass.txt", FileMode.Append, FileAccess.Write))
                    {
                        fileStream.Write(Encoding.UTF8.GetBytes(temp+"\n"));
                    }
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New Password Found " + temp);
                    counter++;
                    Console.WriteLine("Counter : " + counter);
                    condition = 0;
                }
                else
                {
                    condition++;
                }
                Thread.Sleep(50);
                temp = "";
                if (condition == 50)
                {
                    Console.WriteLine("All of possible passwords are made ...");
                    break;
                }


            }
        }
    }
}
