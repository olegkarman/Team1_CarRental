using System;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace CarRental.Models;
public class DealManager
{
    private const string fileName = "dealInfo.json";
    private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    public string ConvertToJson(Dictionary<int, Tuple<int, int, string, float, DateTime>> dealDictionary)
    {
        string jsonString = JsonSerializer.Serialize(dealDictionary, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        return jsonString;
    }

    public
        Dictionary<int, Tuple<int, int, string, float, DateTime>>
        Deserialize(string jsonString)
    {
        if (jsonString == "")
        {
            jsonString = "{}";
        }

        var dealDictionary =
            JsonSerializer.Deserialize
            <Dictionary<int, Tuple<int, int, string, float, DateTime>>>(jsonString);

        return dealDictionary;
    }

    public void SaveDealInfo(Dictionary<int, Tuple<int, int, string, float, DateTime>> newDeal)
    {
        string filePath = Path.Combine(currentDirectory, fileName);

        if (File.Exists(filePath))
        {
            var allDealsDict = Deserialize(GetDealInfoJson());
            allDealsDict = allDealsDict.Concat(newDeal).ToDictionary(x => x.Key, x => x.Value);
            string jsonString = ConvertToJson(allDealsDict);

            File.WriteAllText(filePath, string.Empty);
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(jsonString);
                    Debug.WriteLine(jsonString);
                    Debug.WriteLine($"\n{fileName} is located in {filePath}\n");
                }
            }
        }
        else
        {
            string jsonString = ConvertToJson(newDeal);

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(jsonString);
                    Debug.WriteLine(jsonString);
                    Debug.WriteLine($"\n{fileName} was created in {filePath}\n");
                }
            }
        }
    }

    public string GetAllDealsJson()
    {
        try
        {
            string[] jsonLines = File.ReadAllLines(fileName);
            string jsonString = string.Join(Environment.NewLine, jsonLines);
            return jsonString;
        }
        catch (System.IO.FileNotFoundException)
        {
            return "{}";
        }
    }

    public
        Dictionary<int, Tuple<int, int, string, float, DateTime>>
        GetAllDealsDict()
    {
        try
        {
            string[] jsonLines = File.ReadAllLines(fileName);
            string jsonString = string.Join(Environment.NewLine, jsonLines);
            return Deserialize(jsonString);
        }
        catch (System.IO.FileNotFoundException)
        {
            return new Dictionary<int, Tuple<int, int, string, float, DateTime>>();
        }
        
    }
}
