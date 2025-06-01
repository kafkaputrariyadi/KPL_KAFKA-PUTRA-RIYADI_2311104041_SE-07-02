using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Address
{
    public string streetAddress { get; set; }
    public string city { get; set; }
    public string state { get; set; }
}

public class Course
{
    public string code { get; set; }
    public string name { get; set; }
}

public class DataMahasiswa2311104041
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public int age { get; set; }
    public Address address { get; set; }
    public List<Course> courses { get; set; }

    public static void ReadJSON()
    {
        string path = "jurnal7_1_2311104041.json";
        string json = File.ReadAllText(path);

        var data = JsonSerializer.Deserialize<DataMahasiswa2311104041>(json);

        Console.WriteLine($"Nama     : {data.firstName} {data.lastName}");
        Console.WriteLine($"Gender   : {data.gender}");
        Console.WriteLine($"Age      : {data.age}");
        Console.WriteLine($"Alamat   : {data.address.streetAddress}, {data.address.city}, {data.address.state}");
        Console.WriteLine("Mata Kuliah:");
        foreach (var course in data.courses)
        {
            Console.WriteLine($" - {course.code} : {course.name}");
        }
    }
}
