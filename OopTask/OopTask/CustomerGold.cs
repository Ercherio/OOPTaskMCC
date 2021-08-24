using System;
using System.Collections.Generic;
using System.Text;

namespace OopTask
{
    class CustomerGold:Customer
    {

        public CustomerGold(string id, string pin, decimal balance)
        {
            Id = id;
            Pin = pin;
            Balance = balance;
        }

        public override decimal Withdraw(decimal nominal)
        {
            Balance -= 50000;
            if (nominal <= Balance && Balance>=50000)
            {
                Console.WriteLine("Transaksi Berhasil ");
                return Balance =50000+Balance-nominal;
            }
            else
            {

                Console.WriteLine("Amount exceeded balance");
                return Balance+=50000;

            }

        }

        public override decimal Transfer(decimal nominal)
        {

            Balance -= 50000;
            if (nominal <= Balance && Balance >= 50000)
            {
                Console.WriteLine("Transaksi Berhasil ");
                return Balance = 50000 + Balance - nominal;
            }
            else
            {

                Console.WriteLine("Amount exceeded balance");
                return Balance += 50000;

            }


        }
    }
}
