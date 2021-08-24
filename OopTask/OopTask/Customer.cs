using System;
using System.Collections.Generic;
using System.Text;

namespace OopTask
{
    class Customer
    {
        public decimal Balance { get; protected set; }
        public string Id { get; protected set; }
        public string Pin {protected get;set; }

        public Customer()
        {

        }

        public Customer(string id)
        {
            Id = id;
        }
        public Customer(string id, string pin, decimal balance)
        {
            Id = id;
            Pin = pin;
            Balance = balance;
        }

        public bool CheckPin(string pin)
        {
            if (pin == Pin)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void UpdatePin(string newPin)
        {
            Pin = newPin;
            
        }
        public virtual decimal Withdraw(decimal nominal)
        {
            if (nominal<=Balance)
            {
                Console.WriteLine("Transaksi Berhasil ");
                return Balance -= nominal;
            }
            else
            {

                Console.WriteLine("Amount exceeded balance");
                return Balance;
                
            }
            
        }

        public decimal Deposite(decimal nominal)
        {
            return Balance += nominal;
        }

        public virtual decimal Transfer (decimal nominal)
        {

            if (nominal <= Balance)
            {
                Console.WriteLine("Transaksi Berhasil ");
                return Balance -= nominal;
            }
            else
            {

                Console.WriteLine("Amount exceeded balance");
                return Balance;

            }


        }

        public string Resi()
        {

            DateTime now = DateTime.Now;
            //int day = now.Day;
            //String month = now.Month.ToString().PadLeft(2, '0');
            //String year = now.Year.ToString();
            String dayName = now.DayOfWeek.ToString().ToUpper().Substring(0, 3);
            //int yearInt = Convert.ToInt32(year.Substring(2, 2));

            return $"{dayName}, {now}...\t ID : {Id} \t Saldo Anda : {Balance}";


        }

    }
}
