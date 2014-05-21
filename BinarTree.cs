using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinarTree
{
    class Node
    // рекурсивный класс узла
    {
        public double data;
        public Node parent;
        public Node left;
        public Node right;
        public Node(double data, Node left, Node right, Node parent)
        // конструктор
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
        public void WriteNode(StreamWriter w)
            {
                if (this != null)
                {
                    if (left != null)
                    {
                        w.WriteLine(Convert.ToString(data) + "->" + Convert.ToString(left.data) + ";");
                        left.WriteNode(w);
                    }
                    if (right != null)
                    {
                        w.WriteLine(Convert.ToString(data) + "->" + Convert.ToString(right.data) + ";");
                        right.WriteNode(w);
                    }
                }
            }
    }
    class Tree
    // класс дерева
    {
        public Node top; // корень дерева
        public double Maximum()
        // поиск максимального по значению узла
        {
            if (top != null)
            {
                Node p = top;
                while (p.right != null) p = p.right;
                return p.data;
            }
            else throw new InvalidOperationException("You should fill your tree first");
        }
        public double Minimum()
        // поиск минимального по значению узла
        {
            if (top != null)
            {
                Node p = top;
                while (p.left != null) p = p.left;
                return p.data;
            }
            else throw new InvalidOperationException("You should fill your tree first");
        }
        private void Add(Node p, int val)
        // рекурсивная функция добавления элемента со значением val
        {
            if (p.data < val)
            {
                if (p.right == null)
                    p.right = new Node(val, null, null, p);
                else
                    Add(p.right, val);
            }
            else
            {
                if (p.left == null)
                    p.left = new Node(val, null, null, p);
                else
                    Add(p.left, val);
            }
        }
        public void Add(int value)
        // "обёртка" для функции Add
        {
            if (top == null)
            {
                top = new Node(value, null, null, null);
                return;
            }
            Add(top, value);
        }
        private Node Search(ref Node t, int k)
        // рекурсивная функция поиска элемента по значению
        {
            if ((t == null) || (k == t.data))
                return t;
            else
                if (k < t.data)
                    return Search(ref t.left, k);
                else return Search(ref t.right, k);
        }
        public Node Search(int val)
        // "обёртка" для функции Search
        {
            return Search(ref top, val);
        }
        Node q = new Node(0, null, null, null);
        private void Del(ref Node r)
        {
            if (r.right != null)
                Del(ref r.right);
            else
            {
                q.data = r.data;
                q = r;
                r = r.left;
            }
        }
        private void Del0(int data, ref Node p)
        {
            if (p != null)
                if (data < p.data)
                    Del0(data, ref p.left);
                else
                    if (data > p.data)
                        Del0(data, ref p.right);
                    else
                    {
                        q = p;
                        if (q.right == null)
                            p = q.left;
                        else
                            if (q.left == null)
                                p = q.right;
                            else
                                Del(ref q.left);
                    }
        }
        public void Delete(int data)
        // удаление элемента по значению
        {
            Del0(data, ref top);
        }
        public void WriteTree(string path)
        // запись в текстовый файл
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("digraph G {");
            top.WriteNode(w);
            w.WriteLine("}");
            w.Close();
            f.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tree bt = new Tree();
            Random r = new Random();
            int n = 10;
            for (int i = 0; i < n; i++)
                bt.Add(r.Next(1, 100));
            bt.WriteTree("Tree.txt");
        }
    }
}