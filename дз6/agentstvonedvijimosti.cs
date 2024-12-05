using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace дз6
{
    public abstract class Property
    {
        //расписываем свойства для недвижимости
        public string Address { get; set; } 
        public decimal Price { get; set; } 
        public double Square { get; set; } 
        public string Type { get; set; } 

        // конструктор класса Property
        public Property(string address, decimal price, double squareFootage)
        {
            Address = address; 
            Price = price;
            Square = squareFootage; 
        }
        public abstract void GetDetails();
        public void SetPrice(decimal newPrice)
        {
            Price = newPrice;
        }
        public decimal RealtorPayment()
        {
            return Price * 0.05m;
        }
        public double GetSquare()
        {
            return Square; 
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Тип недвижимости: {Type}, Адрес: {Address}, Цена: {Price}, Площадь: {Square} кв. м."); 
        }
    }
    internal class Apartment : Property
    {
        //свойства квартиры
        public int Floor { get; set; } 
        public bool HasBalcony { get; set; } 
        public string TypeOfApartament { get; set; }

        public Apartment(string address, decimal price, double square, int floor, bool hasBalcony, string typeOfApartment)
            : base(address, price, square) 
        {
            Floor = floor; 
            HasBalcony = hasBalcony; 
            Type = "Квартира"; 
            TypeOfApartament = typeOfApartment;
        }
        public override void GetDetails()
        {
            Console.WriteLine($"Тип квартиры: {TypeOfApartament}, Квартира на {Floor} этаже, Балкон: {HasBalcony}, Адрес: {Address}"); 
        }
        public void SetFloor(int newFloor)
        {
            Floor = newFloor; 
        }
        public double CalculateMaintenanceCost()
        {
            return Square * 0.5; 
        }
    }
    internal class House : Property
    {
        //свойства дома
        public double GardenSize { get; set; } 
        public bool HasGarage { get; set; }
        public House(string address, decimal price, double square, double gardenSize, bool hasGarage)
            : base(address, price, square)
        {
            GardenSize = gardenSize; 
            HasGarage = hasGarage; 
            Type = "Дом"; 
        }
        public override void GetDetails()
        {
            Console.WriteLine($"Дом имеет сад размером {GardenSize}га , Гараж: {HasGarage}, Адрес: {Address}"); 
        }
        public void SetGardenSize(double newSize)
        {
            GardenSize = newSize; 
        }
        public double CalculateMaintenanceCost()
        {
            return Square * 1; 
        }
    }
    public class AgentstvoNedvijimocti
    {
        //свойства для агентства
        public string Name { get; set; }
        public List<Property> Properties { get; set; } 

        public AgentstvoNedvijimocti(string name)
        {
            Name = name; 
            Properties = new List<Property>(); 
        }
        public void AddProperty(Property property)
        {
            Properties.Add(property);
        }
        public void PrintProperties()
        {
            Console.WriteLine("Все доступные объекты в агентстве:"); 
            foreach (var property in Properties) 
            {
                property.GetInfo();
            }
        }
        public void PrintDetailsOfAllProperties()
        {
            foreach (var property in Properties) 
            {
                    property.GetDetails();
            }
        }

    }
}

