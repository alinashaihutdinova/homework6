using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задания_тумакова
{
    public enum AccountType
    {
        текущий,
        сберегательный
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTask();
            FourthTask();
        }
        static void FirstTask()
        {
            Console.WriteLine("Упражнение 7.1");

            /* Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип
            банковского счета (использовать перечислимый тип из упр. 3.1). Предусмотреть методы для
            доступа к данным– заполнения и чтения. Создать объект класса, заполнить его поля и
            вывести информацию об объекте класса на печать.*/

            BankAccount1 myAccount = new BankAccount1();
            myAccount.WriteAccount("123456789", 1098508650.50m, AccountType.сберегательный);//заполняем данные
            Console.WriteLine(myAccount.GetAccountInfo());
        }

        static void SecondTask()
        {
            Console.WriteLine("Упражнение 7.2");

            /* Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы
            номер счета генерировался сам и был уникальным. Для этого надо создать в классе
            статическую переменную и метод, который увеличивает значение этого переменной*/

            BankAccount2 account1 = new BankAccount2();
            BankAccount2 account2 = new BankAccount2();
            BankAccount2 account3 = new BankAccount2();
            Console.WriteLine(account1.ToString());
            Console.WriteLine(account2.ToString());
            Console.WriteLine(account3.ToString());
        }

        static void ThirdTask()
        {
            Console.WriteLine("Упражнение 7.3");

            /*Добавить в класс счет в банке два метода: снять со счета и положить на
            счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае
            положительного результата изменяет баланс*/

            BankAccount3 account = new BankAccount3();
            Console.WriteLine(account.ToString());
            Console.WriteLine("Что вы хотите сделать с балансом:");
            Console.WriteLine("1-Внести деньги на счет");
            Console.WriteLine("2-Снять деньги со счета");
            Console.Write("Введите номер операции (1 или 2): ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: // пополнение счета
                    Console.Write("Введите сумму для пополнения счета: ");
                    decimal addedAmount = decimal.Parse(Console.ReadLine());
                    try 
                    { 
                    account.PutMoney(addedAmount);
                    Console.WriteLine(account.ToString());
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }
                    break;

                case 2: // снятие со счета
                    Console.Write("Введите сумму для снятия со счета: ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    try
                    {
                        account.TakeOffMoney(withdrawAmount);
                        Console.WriteLine(account.ToString());
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                break;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1 или 2");
                break;
            }
        }

        static void FourthTask()
        {
            Console.WriteLine("Домашнее задание 7.1");

            /*Реализовать класс для описания здания (уникальный номер здания,
             высота, этажность, количество квартир, подъездов). Поля сделать закрытыми,
             предусмотреть методы для заполнения полей и получения значений полей для печати.
             Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества
             квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания
             генерировался программно. Для этого в классе предусмотреть статическое поле, которое бы
             хранило последний использованный номер здания, и предусмотреть метод, который
             увеличивал бы значение этого поля.*/

            Building building = new Building(64, 16, 48, 6); 
            Console.WriteLine("Уникальный номер здания: " + building.GetBuildingNumber());
            Console.WriteLine("Высота здания: " + building.GetHeight() + "м");
            Console.WriteLine("Этажность: " + building.GetFloors() + " этажей");
            Console.WriteLine("Количество квартир: " + building.GetApartments());
            Console.WriteLine("Количество подъездов: " + building.GetEntrances());
            Console.WriteLine("Высота этажа: " + building.CalculateFloorHeight() + "м");
            Console.WriteLine("Количество квартир в подъезде: " + building.CalculateApartmentsPerPorch());
        }
    }
    public class BankAccount1
    {
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;
        public void WriteAccount(string accountNumber, decimal balance, AccountType accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = accountType;
        }
        public string GetAccountInfo()
        {
            return $"Account Number: {accountNumber}, Balance: {balance}, Account Type: {accountType}";
        }
    }
    public class BankAccount2
    {
        private static int nextAccountNumber = 1;
        public string AccountNumber { get; private set; }
        public BankAccount2()
        {
            AccountNumber = GenerateAccountNumber();
        }
        private static string GenerateAccountNumber()
        {
            return nextAccountNumber++.ToString();
        }
        public override string ToString()
        {
            return $"Номер счета: {AccountNumber}";
        }
    }
    public class BankAccount3
    {
        private static int nextAccountNumber = 1;
        // поля класса
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; } 
        public BankAccount3()
        {
            AccountNumber = GenerateAccountNumber();
            Balance = 100088889; // начальный баланс
        }
        private static string GenerateAccountNumber()
        {
            return nextAccountNumber++.ToString();
        }
        public void PutMoney(decimal amount)//пополнение счета
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть положительной и больше нуля");
            }

            Balance += amount; 
            Console.WriteLine($"Баланс успешно пополнен на {amount}. Текущий баланс: {Balance}");
        }
        public void TakeOffMoney(decimal amount)//снятие со счета
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной и больше нуля");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Недостаточно средств на счете");
            }

            Balance -= amount;
            Console.WriteLine($"Сумма {amount} успешно снята со счета. Текущий баланс: {Balance}");
        }
        public override string ToString()
        {
            return $"Номер счета: {AccountNumber}, Баланс: {Balance}";
        }
    }
    public class Building
    {
        private static int lastBuildingNumber = 0;
        private uint buildingNumber;
        private double height;
        private uint floors;
        private uint apartments;
        private uint porches;
        public Building(double height, uint floors, uint apartments, uint entrances)
        {
            this.buildingNumber = GenerateBuildingNumber(); 
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.porches = entrances;
        }
        private static uint GenerateBuildingNumber()
        {
            return (uint)(++lastBuildingNumber); 
        }
        public double CalculateFloorHeight()
        {
            if (floors == 0)
            {
                throw new InvalidOperationException("Количество этажей не может быть равно 0");
            }
            return height / floors; //высота этажа
        }
        public uint CalculateApartmentsPerPorch()
        {
            if (porches == 0)
            {
                throw new InvalidOperationException("Количество подъездов не может быть равно 0");
            }
            return apartments / porches; //количество квартир в подъезде
        }
        // методы для получения значений полей
        public uint GetBuildingNumber() => buildingNumber;
        public double GetHeight() => height;
        public uint GetFloors() => floors;
        public uint GetApartments() => apartments;
        public uint GetEntrances() => porches;
    }
}
