using System;


namespace OopTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int trial= 0;
            string input;
            bool isError;
            char transaction;
            decimal amount;
            
            Customer atm1 = new Customer("C01","1234",1000000);
            CustomerGold atm = new CustomerGold("CGO01", "1234", 1000000);

            
            Console.WriteLine("===========================");
            Console.WriteLine("     Welcome to ATM RC     ");
            Console.WriteLine("===========================");
            while (true)
            {
                trial = 0;
                

                do
                {
                    Console.WriteLine("Masukkan PIN Anda ");
                    input = Console.ReadLine();
                    ClearLine();
                    
                    
                    if (trial == 3)
                    {
                        Console.WriteLine("ERROR ! Anda telah 3 salah memasukkan password");
                        Environment.Exit(0);
                    }

                    trial += 1;

                } while (!atm.CheckPin(input) && trial < 3);

                do
                {
                    Console.Clear();
                    transaction = 'n';
                    isError = false;
                    Console.WriteLine("Login Sukses");
                    Console.WriteLine("Anda ingin melakukan transaksi :");
                    Console.WriteLine("1 - Cek Saldo \t 2 - Debet \t 3 - Simpan \t 4 - Transfer \t 5 - Ganti PIN \t 6 - Keluar \n");
                    Console.Write("Pilihan Anda : ");
                    try
                    {
                        int selectMenu = int.Parse(Console.ReadLine());
                        switch (selectMenu)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine($"Saldo Anda : Rp {atm.Balance}");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();

                                break;
                            case 2:

                                Console.Clear();
                                do
                                {
                                    Console.Write("Masukkan nominal yang ingin diambil : Rp ");
                                    amount = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Konfirmasi : Anda akan melakukan Penarikan\n");
                                    Console.Write($"sebesar Rp{amount}  [y/n]");
                                    transaction = Console.ReadLine()[0];
                                } while (transaction != 'Y' && transaction != 'y');
                                
                                Console.WriteLine($"Saldo Anda sekarang : Rp{atm.Withdraw(amount)}");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();


                                break;
                            case 3:
                                
                                do{
                                    Console.Clear();
                                    Console.Write("Masukkan nominal yang ingin disimpan: Rp ");
                                    amount = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Konfirmasi : Anda akan melakukan penyimpanan\n");
                                    Console.WriteLine($"sebesar Rp{amount}  [y/n] ");
                                    transaction = Console.ReadLine()[0];
                                } while (transaction != 'Y' && transaction != 'y') ;
                                
                                Console.WriteLine($"Saldo Anda sekarang : Rp{atm.Deposite(amount)}");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                break;

                            case 4:

                                do
                                {   

                                    Console.Clear();
                                    Console.Write("Masukkan Nomor Rekening tujuan: ");
                                    Customer reciever = new Customer(Console.ReadLine());
                                    Console.Write("Besar nominal transfer: ");
                                    amount = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Konfirmasi : Anda akan melakukan transfer\n");
                                    Console.Write($"sebesar Rp{amount} ke ID: {reciever.Id} [y/n] ");
                                    transaction = Console.ReadLine()[0];
                                } while (transaction != 'Y' && transaction != 'y');

                                Console.WriteLine($"Saldo Anda sekarang : Rp{atm.Transfer(amount)}");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                break;

                            case 5:
                                Console.Write("Masukkan PIN Baru Anda : ");
                                atm.UpdatePin(Console.ReadLine());
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("Terima kasih");
                                Console.WriteLine("Silahkan Ambil Kartu Anda");
                                Console.WriteLine(atm.Resi());
                                
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("ERROR!!! Menu Anda tidak tersedia");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"\nERROR : {e.Message}");
                        isError = true;
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine($"\nERROR : {e.Message}");
                        isError = true;
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }

                } while (isError == true || atm.CheckPin(input));

                Console.Clear();

                //Environment.Exit(0);
                //try
                //{
                //    trial = 3;
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("ERROR ! Anda telah 3 salah memasukkan password");
                //}
            }

        }
        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
