using System;

namespace HW
{
    class Money
    {
        public int Bills { get; protected set; }
        public int Cents { get; protected set; }

        public Money(int bills, int cents)
        {
            this.Bills = bills;
            this.Cents = cents;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Bills}.{Cents}");
        }
    }

    class Product : Money
    {
        public string ProductName { get; private set; }

        public Product(string productName, int bills, int cents) : base(bills, cents)
        {
            this.ProductName = productName;
        }

        public override void Display()
        {
            Console.WriteLine(ProductName);
            base.Display();
        }

        public void ReducePrice()
        {
            Console.Write("Enter amount to reduce the price (e.g. 0.00): ");
            double amountToReduce = double.Parse(Console.ReadLine());
            int reduceBills = (int)amountToReduce;
            int reduceCents = (int)((amountToReduce % 1) * 100);

            if (reduceCents > Cents)
            {
                Bills -= 1;
                Cents += 100;
            }

            Cents -= reduceCents;
            Bills -= reduceBills;
        }
    }

    abstract class Device
    {
        public string DeviceName { get; protected set; }
        public string DeviceDescription { get; protected set; }

        public abstract void MakeSound();
        public abstract void DisplayName();
        public abstract void ShowDescription();
    }

    class Kettle : Device
    {
        public Kettle(string description = "")
        {
            this.DeviceName = "Kettle";
            this.DeviceDescription = description;
        }

        public override void MakeSound()
        {
            Console.WriteLine("*whistling*");
        }

        public override void DisplayName()
        {
            Console.WriteLine($"name: {DeviceName}");
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"description: {DeviceDescription}");
        }
    }

    class Microwave : Device
    {
        public Microwave(string description = "")
        {
            this.DeviceName = "Microwave";
            this.DeviceDescription = description;
        }

        public override void MakeSound()
        {
            Console.WriteLine("*tic*");
        }

        public override void DisplayName()
        {
            Console.WriteLine($"name: {DeviceName}");
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"description: {DeviceDescription}");
        }
    }

    class Car : Device
    {
        public Car(string description = "")
        {
            this.DeviceName = "Car";
            this.DeviceDescription = description;
        }

        public override void MakeSound()
        {
            Console.WriteLine("*wroom*");
        }

        public override void DisplayName()
        {
            Console.WriteLine($"name: {DeviceName}");
        }

        public override void ShowDescription()
        {
            Console.WriteLine($"description: {DeviceDescription}");
        }

        class SteamMelter : Device
        {
            public SteamMelter(string description = "")
            {
                this.DeviceName = "Steam Melter";
                this.DeviceDescription = description;
            }

            public override void MakeSound()
            {
                Console.WriteLine("*bulk*");
            }

            public override void DisplayName()
            {
                Console.WriteLine($"name: {DeviceName}");
            }

            public override void ShowDescription()
            {
                Console.WriteLine($"description: {DeviceDescription}");
            }
        }

        class Program
        {
            static int Main(string[] args)
            {
                Product milk = new Product("Milk", 10, 10);
                milk.Display();
                milk.ReducePrice();
                milk.Display();

                SteamMelter melter = new SteamMelter("Philips");
                melter.DisplayName();
                melter.ShowDescription();
                melter.MakeSound();

                return 0;
            }
        }
    }
}

