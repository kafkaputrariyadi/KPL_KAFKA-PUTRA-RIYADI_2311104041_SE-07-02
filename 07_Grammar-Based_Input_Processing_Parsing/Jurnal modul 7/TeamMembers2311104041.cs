using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Member
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public int age { get; set; }
    public string nim { get; set; }
}

public class TeamData
{
    public List<Member> members { get; set; }
}

public class TeamMembers2311104041
{
    public static void ReadJSON()
    {
        string path = "jurnal7_2_2311104041.json";
        string json = File.ReadAllText(path);

        TeamData data = JsonSerializer.Deserialize<TeamData>(json);

        Console.WriteLine("Team member list:");
        foreach (var member in data.members)
        {
            Console.WriteLine($"{member.nim} {member.firstName} {member.lastName} ({member.age} {member.gender})");
        }
    }
}
