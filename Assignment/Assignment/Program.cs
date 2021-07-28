using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            int units;
            Console.WriteLine("Please Enter the Number of Units: ");
            units = int.Parse(Console.ReadLine());
            float unitprice = 1.20f;
            double BillAmount;
            if(units<100)
            {
                BillAmount = unitprice * units;
                Console.WriteLine("CurrentBillAmount:{0}", BillAmount);
            }
            else if(units>100 && units<300)
            {
                BillAmount = (100 * 1.20) + (units - 100) * 2;
                Console.WriteLine("CurrentBillAmount:{0}", BillAmount);
            }
            else if(units>300)
            {
                BillAmount = (100 * 1.20) + (200 * 2) + (units - 300) * 3;
                Console.WriteLine("CurrentBillAmount:{0}", BillAmount);
            }



        }
    }
}
