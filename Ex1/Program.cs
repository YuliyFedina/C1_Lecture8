using System;
using Ex1.Model;
using Ex1.Model.Accounts;

namespace Ex1
{
    class Program
    {
        static void Main()
        {
            //Добавить обработку параметров в методах пополнения и списания денег со счета.
            //Выбрасывать соответствующие исключения.
            //Добавить обработку исключений при использовании этих методов.

            //Добавить проверку входных параметров и исключительные ситуации в
            //задачи “Банковские счета” и “Дроби”

            Console.WriteLine($"Первая часть задания");
            IFundsTransfer bank = new Bank();
            try
            {
                SendFunds(bank);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так");
            }

            Console.WriteLine("Программа завершена");

            Post post = new Post();
            SendFunds(post);

            Console.WriteLine($"Вторая часть задания");
            var rnd = new Random();
            var n = 2;
            const int maxValue = 10;

            var array = new SimpleFraction[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new SimpleFraction(rnd.Next(-maxValue, maxValue), rnd.Next(0, maxValue));
                Console.WriteLine(array[i]);
            }

            var sumOfFractions = new SimpleFraction(0, 1);

            for (int i = 0; i < n; i++)
            {
                sumOfFractions += array[i];
            }

            Console.WriteLine($"Сумма всех дробей = {sumOfFractions}");
        }

        private static void SendFunds(IFundsTransfer transfer)
        {
            SavingAccount me = new SavingAccount(001, 2000);
            try
            {
                me.AddFunds(-100);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            SavingAccount you = new SavingAccount(002, 3000);

            transfer.TransferFunds(me, you, 100);

            Console.WriteLine("Перевод завершен");
        }
    }
}
