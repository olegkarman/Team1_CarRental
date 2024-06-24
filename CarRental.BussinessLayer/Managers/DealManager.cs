using System;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace CarRental.BussinessLayer.Managers;
public class DealManager
{
    private string fileName;
    private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    // MOVE IT INTO SEPARATE MANAGER. 'CRUD'-OPERATIONS SHOULD BE INSTEAD. (YPARKHOMENKO)
    public DealManager()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        fileName = Path.Combine(Directory.GetCurrentDirectory(), "dealInfo.json");
    }

    public string ConvertToJson(Dictionary<int, Tuple<string, string, string, float, DateTime>> dealDictionary)
    {
        string jsonString = JsonSerializer.Serialize(dealDictionary, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        return jsonString;
    }

    public Dictionary<int, Tuple<string, string, string, float, DateTime>> Deserialize(string jsonString)
    {
        if (jsonString == "")
        {
            jsonString = "{}";
        }

        var dealDictionary =
            JsonSerializer.Deserialize
            <Dictionary<int, Tuple<string, string, string, float, DateTime>>>(jsonString);

        return dealDictionary;
    }

    public void SaveDealInfo(Dictionary<int, Tuple<string, string, string, float, DateTime>> newDeal)
    {
        string filePath = Path.Combine(currentDirectory, fileName);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(fileName);
            var allDealsDict = Deserialize(jsonData);
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

    /*public string GetAllDealsJson()
    {
        try
        {
            var d = new Deal("1", "1", "purchase", 1.2f);
            d.Name = "Mariia";

            //var a = File.ReadAllText(fileName);

            var b = Newtonsoft.Json.JsonConvert.SerializeObject(d);

            using (FileStream fs = new FileStream(Path.Combine(currentDirectory, fileName), FileMode.Create, FileAccess.Write))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(d);
                JsonSerializer.Serialize(fs, d, JsonSerializerOptions.Default);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(b);
                    Debug.WriteLine(json);
                    Debug.WriteLine($"\n{fileName} was created in {Path.Combine(currentDirectory, fileName)}\n");
                }
            }

            //var b = JsonSerializer.Deserialize<Dictionary<int, Tuple<string, string, string, float, DateTime>>>(a);
            //string[] jsonLines = File.ReadAllLines(fileName);
            //string jsonString = string.Join(Environment.NewLine, jsonLines);
            return "json";
        }
        catch (System.IO.FileNotFoundException)
        {
            return "{}";
        }
    }*/

    public Dictionary<int, Tuple<string, string, string, float, DateTime>> GetAllDealsDict()
    {
        try
        {
            string[] jsonLines = File.ReadAllLines(fileName);
            string jsonString = string.Join(Environment.NewLine, jsonLines);
            return Deserialize(jsonString);
        }
        catch (System.IO.FileNotFoundException)
        {
            return new Dictionary<int, Tuple<string, string, string, float, DateTime>>();
        }

    }
}
