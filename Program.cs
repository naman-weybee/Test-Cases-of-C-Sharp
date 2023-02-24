using ConsoleApp1;
using NPOI.SS.Formula.Functions;
using SixLabors.ImageSharp.ColorSpaces;
using System;
using System.Collections;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Test
{
    class Student
    {
        delegate int Square(int num);
        public delegate void AnonymousFun();
        public int rollno { get; set; }
        public string name { get; set; }
        public Student(int rollno, string name)
        {
            this.rollno = rollno;
            this.name = name;
        }

        public static void Display()
        {
            Console.WriteLine();
        }
        public static void Display1(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public class DeserializeExample
        {
            public static void Main(string[] args)
            {
                //Command Line Arguments
                Console.WriteLine($"length: {args.Length}");
                foreach (var item in args)
                {
                    Console.WriteLine(item);
                }

                //Anonymous Function - Lambda Expression
                Square Getvalue = x => x * x;
                int i1 = Getvalue(2);
                Console.WriteLine(i1);

                //Anonymous Function - Anonymous Method
                AnonymousFun fun = delegate ()
                {
                    Console.WriteLine("This is anonymous function");
                };
                fun();

                //Reflection
                Type type = typeof(Student);
                Console.WriteLine("Type: " + type);
                MethodInfo[] methods = type.GetMethods();
                PropertyInfo[] properties = type.GetProperties();

                Console.WriteLine(type.IsClass);
                Console.WriteLine(type.IsArray);
                Console.WriteLine(type.IsNested);
                Console.WriteLine(type.IsPrimitive);
                Console.WriteLine(type.IsSerializable);
                Console.WriteLine(type.Name);
                Console.WriteLine(type.Namespace);
                Console.WriteLine(type.Module);

                foreach (var prop in properties)
                {
                    Console.Write("-----Property: " + prop.Name);
                    Console.Write(", Property Type: " + prop.PropertyType);
                    Console.WriteLine();
                }

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine("-----Method: " + method.Name);
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var param in parameters)
                        Console.WriteLine("----------Parameter: " + param.Name);
                }

                Thread mainThread = Thread.CurrentThread;
                mainThread.Name = "MainThread";

                Thread thread1 = new(() => CountUp("hi from 1"));
                Thread thread2 = new(() => CountDown("hi from 2"));

                thread1.Start();
                //thread1.Join();
                thread2.Start();

                if (thread1.IsAlive)
                    thread1.Priority = ThreadPriority.Highest;
                if (thread2.IsAlive)
                    thread2.Priority = ThreadPriority.Lowest;

                //Properties of Thread
                if (thread1.IsAlive)
                {
                    bool x1 = thread1.IsAlive;
                    bool xy = thread1.IsBackground;
                    int xy1 = thread1.ManagedThreadId;
                    string xy2 = thread1.Name;
                    ThreadPriority xy3 = thread1.Priority;
                    ThreadState xy4 = thread1.ThreadState;

                    Console.WriteLine(x1);
                    Console.WriteLine(xy);
                    Console.WriteLine(xy1);
                    Console.WriteLine(xy2);
                    Console.WriteLine(xy3);
                    Console.WriteLine(xy4);
                }

                //Garbage Collection Method
                GC.Collect();

                //HashTable
                HaseTable();

                //Extension Methods For int
                int num = 1020504044;
                int countOfNum = num.GetDigit();
                Console.WriteLine(countOfNum);

                //Reverse the String
                Console.WriteLine(ReverseString("Make String Reverse"));

                //Reverse the Order of Word in String
                Console.WriteLine(ReverseWordOrder("hello from words"));

                //Check For Palindrome String
                Console.WriteLine(CheckForPalindromeString("csharp"));
                Console.WriteLine(CheckForPalindromeString("naman"));

                //Get SubString From String
                GetSubStringFromString("abcd");
            }

            public static void CountUp(string name)
            {
                for (int i = 1; i < 11; i++)
                {
                    Console.WriteLine("Thread #1: " + i + " Seconds " + name);
                    Thread.Sleep(1000);
                }
            }
            public static void CountDown(string name)
            {
                for (int i = 10; i > 0; i--)
                {
                    Console.WriteLine("Thread #2: " + i + " Seconds " + name);
                    Thread.Sleep(1000);
                }
            }

            public static void HaseTable()
            {
                Hashtable hashTable = new();
                hashTable.Add(1, "a");
                hashTable.Add(2, "b");

                foreach (var key in hashTable.Keys)
                {
                    Console.WriteLine(key + ": " + hashTable[key]);
                }
            }

            public static string ReverseString(string str)
            {
                string xyz = string.Empty;
                char[] chars = str.ToCharArray();
                for (int i = chars.Length - 1; i >= 0; i--)
                {
                    xyz += chars[i].ToString();
                }
                return xyz;
            }

            public static string ReverseWordOrder(string str)
            {
                StringBuilder abc = new();
                string[] xyz = str.Split(" ");
                for (int i = xyz.Length - 1; i >= 0; i--)
                {
                    abc.Append(xyz[i]);
                    abc.Append(' ');
                }
                return abc.ToString();
            }

            public static bool CheckForPalindromeString(string str)
            {
                string xyz = ReverseString(str);
                if (str.ToLower() == xyz.ToLower())
                    return true;
                else
                    return false;
            }

            public static void GetSubStringFromString(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    StringBuilder subString = new(str.Length - i);
                    for (int j = i; j < str.Length; j++)
                    {
                        subString.Append(str[j]);
                        Console.Write(subString + " ");
                    }
                }
            }
        }
    }
}