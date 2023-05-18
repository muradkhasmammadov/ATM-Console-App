using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName = "Murad";
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNum() { return cardNum; }
    public int getPin() { return pin; }
    public String getFirstName() { return firstName; }
    public String getLastName() { return lastName; }
    public double getBalance() { return balance; }
    public void setNum(String newCardNum) { cardNum = newCardNum; }
    public void setPin(int newPin) { pin = newPin; }
    public void setFirstName(String newFirstName) { firstName = newFirstName; }
    public void setLastName(String newLastName) { lastName = newLastName; }
    public void setBalance(double newBalance) { balance = newBalance; }



    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options.....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());  
            currentUser.setBalance(currentUser.getBalance() + deposit); 
            Console.WriteLine("Thanks for your deposit! Your current balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal) 
            {
                Console.WriteLine("Insufficent balance. Try again!");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for withdraw!");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("2131741312139324", 1234, "Murad", "Khasmammadov", 139.63));
        cardHolders.Add(new cardHolder("5241495389231924", 5241, "Tom", "Anderson", 60.12));
        cardHolders.Add(new cardHolder("2424918949148202", 6215, "Jack", "Curry", 731.52));
        cardHolders.Add(new cardHolder("2984940230139910", 7452, "Henry", "Stephan", 52.6 ));
        cardHolders.Add(new cardHolder("5989103582084235", 7834, "Asensio", "Lucas", 523.12));


        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum= Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(x=>x.cardNum== debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognised. Try again!"); }
            }
            catch { Console.WriteLine("Card not recognised. Try again!"); }
        }
        
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Try again!"); }
            }
            catch { Console.WriteLine("Incorrect pin. Try again!"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        } 
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}