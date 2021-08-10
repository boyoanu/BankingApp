using System;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount janesAccount = new BankAccount("Jane Okeke", "0130939002", "Current");

            BankAccount boyosAccount = new BankAccount("Boyo Odometa", "0999906677", "Current", 0.00);

            BankAccount temisAccount = new BankAccount("Temi Tegbe", "0130969002", "Savings", 10000);
        }
    }
}
