using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP
{
    internal class Program
    {
        //Refrigerator, Products, fruits, vegetables, food

        class Refrigerator
        {
            private double capacity = 150;
            private bool stateDoor = false;
            private int minTemperature = -10;
            private int maxTemperature = 15;
            private int standartTemperature = 5;
            protected double freeCapacity = capacity;

            public void GetCapacity()
            {
                Console.WriteLine($"Доступний об'єм холодильника: {freeCapacity} л.");
            }

            public void GetStandartTemperature() 
            {
                Console.WriteLine($"Актуальна температура холодильника: {standartTemperature}");
                Console.WriteLine();
               
            }

            public void ChoiseTemperature()
            {
                Console.WriteLine($"Актуальна температура холодильника: {standartTemperature}");
                Console.WriteLine("Бажаєте її змінити? Y or N");
                string choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                    Console.WriteLine("Введіть бажану температуру:");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    while (temp > maxTemperature)
                    {
                        Console.WriteLine($"Температура холодильника не може перевищувати {maxTemperature}");
                        Console.WriteLine("Введіть інше значення");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    while (temp < minTemperature)
                    {
                        Console.WriteLine($"Температура холодильника не може бути нижче: {minTemperature}");
                        Console.WriteLine("Введіть інше значення");
                        temp = Convert.ToInt32(Console.ReadLine());
                    }
                    standartTemperature = temp;
                    Console.WriteLine($"температуру змінено, актуальна температура: {standartTemperature}");
                }
                
            }


        }
        abstract class Product : Refrigerator
        {
            protected string name;
            protected double weight;
            protected double price;

            static protected double globalPrice = 0;
            static protected double globalWeight = 0;

            public void GetGlobalPrice()
            {
                Console.WriteLine($"Загальна ціна усіх продуктів в холодильнику: {globalPrice} грн.");
            }

            public void GetGlobalWeight()
            {
                Console.WriteLine($"Загальний кількість продуктів в холодильнику: {globalWeight} кг.");
            }

        }

        class Vegetables : Product 
        {
            private bool isClean;
            public Vegetables(string name, double weight, double price, bool isClean)
            {
                this.name = name;
                this.weight = weight;
                this.price = price;
                this.isClean = isClean;
                freeCapacity -= weight;
                globalPrice += price;
                globalWeight += weight;
            }
        }
        class Fruits : Product
        {
            private bool isSweet;

            public Fruits(string name, double weight, double price, bool isSweet)
            {
                this.name = name;
                this.weight = weight;
                this.price = price;
                this.isSweet = isSweet;
                freeCapacity -= weight;
                globalPrice += price;
                globalWeight += weight;
            }
        }
        class Food : Product
        {
            private bool isFresh;

            public Food(string name, double weight, double price, bool isFrash)
            {
                this.name = name;
                this.weight = weight;
                this.price = price;
                this.isFresh = isFresh;
                freeCapacity -= weight;
                globalPrice += price;
                globalWeight += weight;
            }

        }
        static void Main(string[] args)
        {
            Refrigerator r1 = new Refrigerator();
            r1.GetStandartTemperature();
            r1.ChoiseTemperature();
            r1.GetStandartTemperature();
            Console.WriteLine();
            
            Vegetables tomato = new Vegetables("Tomato", 5, 14, true);


            
        }
    }
}
