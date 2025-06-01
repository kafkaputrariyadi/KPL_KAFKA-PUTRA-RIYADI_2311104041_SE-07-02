using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GlossDef
{
    public string para { get; set; }
    public List<string> GlossSeeAlso { get; set; }
}

public class GlossEntry
{
    public string ID { get; set; }
    public string SortAs { get; set; }
    public string GlossTerm { get; set; }
    public string Acronym { get; set; }
    public string Abbrev { get; set; }
    public GlossDef GlossDef { get; set; }
    public string GlossSee { get; set; }
}

public class GlossList
{
    public GlossEntry GlossEntry { get; set; }
}

public class GlossDiv
{
    public string title { get; set; }
    public GlossList GlossList { get; set; }
}

public class Glossary
{
    public string title { get; set; }
    public GlossDiv GlossDiv { get; set; }
}

public class GlossaryRoot
{
    public Glossary glossary { get; set; }
}

public class GlossaryItem2311104041
{
    public static void ReadJSON()
    {
        string path = "jurnal7_3_2311104041.json";
        string json = File.ReadAllText(path);

        GlossaryRoot data = JsonSerializer.Deserialize<GlossaryRoot>(json);

        var entry = data.glossary.GlossDiv.GlossList.GlossEntry;

        Console.WriteLine("=== Gloss Entry ===");
        Console.WriteLine($"ID        : {entry.ID}");
        Console.WriteLine($"Term      : {entry.GlossTerm}");
        Console.WriteLine($"Acronym   : {entry.Acronym}");
        Console.WriteLine($"Abbrev    : {entry.Abbrev}");
        Console.WriteLine($"Definition: {entry.GlossDef.para}");
        Console.WriteLine("See Also  : " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
        Console.WriteLine($"See       : {entry.GlossSee}");
    }
}
