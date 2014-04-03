using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Программа выводит количество отрицательных элементов, стоящих после каждого элемента списка
namespace NodeStekQueue
{
    class MyNode
    // Рекурсивный класс узла
    {
        public double inf;
        public MyNode next;
        // Конструктор
        public MyNode(double inf, MyNode next)
        {
            this.inf = inf;
            this.next = next;
        }
    }
    class MyList
    // Класс списка
    {
        public MyNode head;
        public int count;
        public MyList()
        // Конструктор списка
        {
            head = null;
            count = 0;
        }
        public void Add(double inf)
        //Вставка последним элементом
        {
            if (head == null) head = new MyNode(inf, null);
            else
            {
                MyNode p = head;
                for (int i = 0; i < count - 1; i++)
                    p = p.next;
                p.next = new MyNode(inf, null);
            }
            count++;
        }
        public void Delete(int index)
        // Удаление по индексу
        {
            if (index == 0) head = head.next;
            else
            {
                MyNode p = head;
                for (int i = 0; i < index-2; i++)
                    p = p.next;
                if (p.next != null)
                    p.next = p.next.next;
            }
            count--;
        }
        public void Insert(double value, int index)
        // Вставка по индексу
        {
            if (index == 0) head = new MyNode(value, null);
            else
            {
                MyNode p = head;
                for (int i = 0; i < index-2; i++)
                    p = p.next;
                p.next = new MyNode(value, p.next);
                count++;
            }
        }
        public void Printer()
        // Вывод списка
        {
            MyNode p = head;
            do
            {
                Console.Write("{0} ", p.inf);
                p = p.next;
            }
            while (p != null);
            Console.WriteLine();
        }
        public void NegativeNext()
        // Метод, выполняющий исходную задачу
        {
            int k;
            MyNode p = head;
            for (int j = 0; j < count; j++)
            {
                k = 0;
                for (int i = 0; i < count; i++)
                {
                    if (p.next != null)
                    {
                        if (p.next.inf < 0) k++;
                        p = p.next;
                    }
                    else if (p.next == null) break;
                }
                Console.Write("{0} ", k);
                p = head.next;
                if (p.next != null) head.next = p.next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double a; int x, t;
            MyList L = new MyList();
            Console.Write("Введите количество элементов: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите элементы: ");
            for (int i = 0; i < n; i++)
                L.Add(double.Parse(Console.ReadLine()));
            Console.WriteLine("Ваш список:");
            L.Printer();
            Console.WriteLine("Вставка элемента - 1, удаление элемента - 2, выполнение исходной задачи - 3");
            t = int.Parse(Console.ReadLine());
            switch (t)
            {
                case 1:
                    Console.WriteLine("Введите значение и номер элемента");
                    a = double.Parse(Console.ReadLine());
                    x = int.Parse(Console.ReadLine());
                    L.Insert(a, x);
                    L.Printer();
                    break;
                case 2:
                    Console.WriteLine("Введите номер элемента, который вы хотите удалить");
                    x = int.Parse(Console.ReadLine());
                    L.Delete(x);
                    L.Printer();
                    break;
                case 3:
                    Console.WriteLine("Характеристический вектор списка:");
                    L.NegativeNext();
                    L.Printer();
                    break;
            }
            Console.ReadKey();
        }
    }
}