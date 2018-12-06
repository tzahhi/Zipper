using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipper
{
    class Program
    {

        public const int MAX_DIGITS = 64;

        static void Main(string[] args)
        {
            //Task task1 = Task.Factory.StartNew(WithZeros);
            Task task2 = Task.Factory.StartNew(WithoutZeros);

            //task1.Wait();
            task2.Wait();
        }

        private static void WithoutZeros()
        {
            long password = 1;
            //int counter = 0;
            bool done = false;

            while (!done)
            {
                // int counterTimes = 0;
                // Console.WriteLine(p);

                int numOfPasswordDigits = (int)Math.Floor(Math.Log10(password) + 1);
                for (int i = 0; i <= MAX_DIGITS - numOfPasswordDigits ; i++)
                {
                    string passwordStr = password.ToString().PadLeft(i + numOfPasswordDigits, '0');
                    Console.WriteLine(passwordStr);
                    try
                    {
                        //var zip = ZipFile.Read("New folder\\sss.zip");
                        //zip.Entries.First().ExtractWithPassword(passwordStr);
                        if (ZipFile.CheckZipPassword("New folder\\clues.zip", passwordStr))
                        {
                            Console.WriteLine("SUCCESS " + passwordStr);
                            done = true;
                            break;
                        }
                        //Console.WriteLine("SUCCESS " + passwordStr);
                        
                    }
                    catch (Exception e)
                    {

                    }

                }

                password++;
                //counter++;

                //if (counter == 100000)
                //{
                //    Console.WriteLine("counter " + counterTimes);
                //    counter = 0;
                //    counterTimes++;
                //}
            }
        }

        private static void WithZeros()
        {
            int paddingZeros = 0;
            long currentPassword = 0;

            // fill with zeros
            for (int i = 0; i < MAX_DIGITS; i++)
            {
                string currentPasswordAsString = currentPassword.ToString().PadLeft(paddingZeros, '0');
                //Console.WriteLine(currentPasswordAsString);


                try
                {
                    //var zip = ZipFile.Read("New folder\\clues.zip");
                    //zip.Entries.First().ExtractWithPassword(currentPasswordAsString);
                    if (ZipFile.CheckZipPassword("New folder\\clues.zip", currentPasswordAsString))
                    {
                        Console.WriteLine("SUCCESS " + currentPasswordAsString);
                    }
                    //Console.WriteLine("SUCCESS " + currentPasswordAsString);
                }
                catch (Exception e)
                { }


                paddingZeros++;
            }

            // start increment, padding is 64, currentPassword is 0
            int digits = 1;
            for (int k = 0; k < 9999; k++)//while (true)
            {
                for (int j = 0; j < Math.Pow(10, digits); j++) // till 10, 100, 1000 etc
                {
                    currentPassword++;
                    string currentPasswordAsString = currentPassword.ToString().PadLeft(paddingZeros, '0');
                    // Console.WriteLine(currentPasswordAsString);

                    try
                    {

                        if(ZipFile.CheckZipPassword("New folder\\clues.zip", currentPasswordAsString))
                        {
                            Console.WriteLine("SUCCESS " + currentPasswordAsString);
                        }

                        //var zip = ZipFile.Read("New folder\\clues.zip");
                        //zip.Entries.First().ExtractWithPassword(currentPasswordAsString);
                        
                    }
                    catch (Exception e)
                    {

                    }

                }

                digits++;
                //paddingZeros--;
            }
        }
    }
}
