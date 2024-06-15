using System;

public class AtmApplication
{
    private Bank bank;

    public AtmApplication()
    {
        bank = new Bank();
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("ATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    SelectAccount();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        Console.WriteLine("Enter Account Number:");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Initial Balance:");
        double initialBalance = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Interest Rate:");
        double interestRate = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Account Holder's Name:");
        string accountHolderName = Console.ReadLine();

        Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
        bank.AddAccount(newAccount);

        Console.WriteLine("Account created successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void SelectAccount()
    {
        Console.WriteLine("Enter Account Number:");
        int accountNumber = int.Parse(Console.ReadLine());

        Account account = bank.RetrieveAccount(accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        bool accountMenu = true;
        while (accountMenu)
        {
            Console.Clear();
            Console.WriteLine("Account Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(account.GetBalance());
                    break;
                case "2":
                    Console.WriteLine("Enter amount to deposit:");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    Console.WriteLine("Deposit successful.");
                    break;
                case "3":
                    Console.WriteLine("Enter amount to withdraw:");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    if (account.Withdraw(withdrawAmount))
                    {
                        Console.WriteLine("Withdrawal successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Transactions:");
                    foreach (var transaction in account.GetTransactions())
                    {
                        Console.WriteLine(transaction);
                    }
                    break;
                case "5":
                    accountMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}