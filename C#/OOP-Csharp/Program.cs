﻿using System;

namespace OOP_Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 3;
            Person[] persons = new Person[total];

            for (int i = 0; i < total; i++)
            {
                persons[i] = new Person()
                {
                    Name = Console.ReadLine()
                };
            }

            for (int i = 0; i < total; i++)
            {
                Console.WriteLine(persons[i].ToString());
            }

            Console.ReadLine();

        }
    }
    //
    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }


        public override string ToString()
        {
            return "Hello! My name is " + Name;
        }
        ~Person()
        {
            Name = string.Empty;
        }
    }



}