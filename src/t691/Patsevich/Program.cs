using System;
using System.Threading;
namespace ConsoleApp1
{
    class pet
    {
        public string name;
        public int hp;
        public int food;
        public int water;
        public bool isdead;
        public pet(string name, int hp, int food, int water)
        {
            this.hp = hp;
            this.food = food;
            this.water = water;
            this.name = name;
        }
        public void vivod()
        {
            Console.WriteLine("F1 - дать еды. F2 - воды\nИмя питомца: {0}   Жизни: {1}   Еда: {2}   Вода: {3}", name, hp, food, water);
        }
        public void da(ref int a)
        {
            if (a < 0)
               a = 0;
            else if (a > 20)
                a = 20;
        }
        public void rab()
        {
            bool cd = true, cdhp = true;
            while (isdead == false)
            {
                vivod();
                DateTime tt = DateTime.Now;
                int t = Convert.ToInt32(tt.Second);
                if (t % 5 != 0)
                    cd = true;
                if (t % 10 != 0)
                    cdhp = true;
                if ((t % 5 == 0 || t == 0) && cd)
                {
                    food -= 2; water -= 2; cd = false;
                }
                da(ref water);
                da(ref food);
                if (water == 0 && food == 0 && cdhp && t % 10 == 0)
                { hp--; cdhp = false; }
                if (hp == 0)
                    isdead = true;
                Thread.Sleep(50);
                Console.Clear();
            }
        }
        public void knopkaF1()
        {
            while (isdead == false)
            {
                if (Console.ReadKey().Key == ConsoleKey.F1)
                { food += 4; Console.Clear(); }
            }
        }
        public void knopkaF2()
        {
            while (isdead == false)
            {
                if (Console.ReadKey().Key == ConsoleKey.F2)
                { water += 4; Console.Clear(); }
            }
        }
    }
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя питомца");
            pet biba = new pet(Console.ReadLine(), 10, 20, 20);
            Thread potok1 = new Thread(biba.rab);
            Thread potok2 = new Thread(biba.knopkaF1);
            Thread potok3 = new Thread(biba.knopkaF2);
            potok1.Start();
            potok2.Start();
            potok3.Start();
            Console.WriteLine("ОН СДОХ");
            Console.ReadKey();
        }
    }
}
