using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Программа выводит количество отрицательных элементов, стоящих после каждого элемента списка
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
    {
        public MyNode head;
        public int count;

        public MyList()
        {
            head = null;
            count = 0;
        }
        // Вставка последним элементом
        public void Add(double inf)
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
        // Вывод списка
        public void Printer()
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
        // Метод, выполняющий исходную задачу
        public void NegativeNext(MyList A)
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
                        if(p.next.inf < 0) k++;
                        p = p.next;
                    }
                    else if (p.next == null) break;
                }
                Console.Write("{0} ",k);
                p = head.next;
                if (p.next != null) head.next = p.next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList L = new MyList();
            Console.WriteLine("Введите количество элементов: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите элементы: ");
            for (int i = 0; i < n; i++)
                L.Add(double.Parse(Console.ReadLine()));
            Console.WriteLine("Ваш список: ");
            L.Printer();
            Console.WriteLine("Характеристический вектор списка: ");
            L.NegativeNext(L);
            Console.ReadKey();
        }
    }
}
