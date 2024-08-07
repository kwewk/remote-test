﻿using System.Text.Json;

// сохранение данных
using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    Person tom = new Person("Dave", 23);
    await JsonSerializer.SerializeAsync<Person>(fs, tom);
    Console.WriteLine("Data has been saved to file");
}

// чтение данных
using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);
    Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
}

class Person
{
    public string Name { get; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}