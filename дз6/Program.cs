using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgentstvoNedvijimocti agency = new AgentstvoNedvijimocti("Агентство недвижимости Иди Бритт"); 
            Console.WriteLine(agency.Name);
            Apartment apartment1 = new Apartment("ул. Гоголя, 52", 19990000, 150, 11, true, "студия"); 
            Apartment apartment2 = new Apartment("ул. Чистопольская, 79", 25000000, 200, 9, true, "многокомнатная");
            Apartment apartment3 = new Apartment("ул. Восстания, 81", 11399000, 100, 7, false , "однокомнатная");
            House house1 = new House("Дубки КАИ", 17499000, 200, 150, true); 
            House house2 = new House("Осиново", 13499000, 150, 100, false);
            House house3 = new House("Лаишево", 21499000, 250, 200, true);
            agency.AddProperty(apartment1); 
            agency.AddProperty(apartment2);
            agency.AddProperty(apartment3);
            agency.AddProperty(house1);
            agency.AddProperty(house2);
            agency.AddProperty(house3);
            agency.PrintProperties();
            agency.PrintDetailsOfAllProperties();
            decimal maxPrice = 20000000;
            Console.WriteLine("Объекты до 20000000:");
            foreach (var property in agency.Properties)
            {
                if (property.Price <= maxPrice)
                {
                    property.GetInfo(); 
                    property.GetDetails(); 
                }
            }
            
        }
    }
}
