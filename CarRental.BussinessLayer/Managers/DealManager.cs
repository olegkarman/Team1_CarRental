//using System.Text.Json;
//using System.IO;
using CarRental.BussinessLayer.Interfaces;
using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Validators;
using CarRental.Data.Models.RecordTypes;
using Dapper;
using Microsoft.Data.SqlClient;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using System.Diagnostics;

namespace CarRental.BussinessLayer.Managers;

public class DealManager : IDealManager
{
    // FIELDS

    private const string _invalidName = "INVALID";

    public IIndexValidation IndexValidator { get; init; }
    public INameValidation NameValidator { get; init; }
    public INullValidation Validator { get; init; }

    // PROPERTIES

    internal IDataContext DapperContext { get; init; }

    // CONSTRUCTORS

    public DealManager()
    {
        
    }

    public DealManager
    (
        IIndexValidation indexValidator,
        INameValidation nameValidator,
        INullValidation nullValidator,
        IDataContext dapperContext
    )
    {
        IndexValidator = indexValidator;
        NameValidator = nameValidator;
        Validator = nullValidator;

        DapperContext = dapperContext;
    }
    // METHODS

    // CREATE

    public async Task<Deal> AddDealIntoDatabaseAsync(Deal deal, string connectionString)
    {
        try
        {
            SqlConnection connection = DapperContext.OpenConnection(connectionString);

            string sqlStoredProcedureName = "CreateDeal";

            object arguments = new
            {
                Id = deal.Id,
                CarId = deal.CarId,
                VinCode = deal.VinCode,
                CustomerId = deal.CustomerId,
                Price = deal.Price,
                DealType = deal.DealType,
                Name = deal.Name
            };

            IEnumerable<Deal> resultDeals = await connection.QueryAsync<Deal>(sqlStoredProcedureName, arguments);

            DapperContext.CloseConnection(connection);

            Deal resultDeal = resultDeals.SingleOrDefault();

            return resultDeal;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public Deal GetNewDeal(string name, string customerId, string vinCode, Guid carId, string dealType, float price)
    {
        name = name + Guid.NewGuid().ToString().Substring(24);

        Deal deal = new Deal
        {
            Id = Guid.NewGuid(),
            Name = name,
            CustomerId = customerId,
            VinCode = vinCode,
            CarId = carId,
            DealType = dealType,
            Price = price
        };

        return deal;
    }

    public async Task<DealDto> GetNewDealAsync
    (
        string connectionString,
        string name,
        string customerId,
        string vinCode,
        Guid carId,
        string dealType,
        float price
    )
    {
        try
        {
            name = name + Guid.NewGuid().ToString().Substring(24);

            Guid id = Guid.NewGuid();

            var sqlInsert = "CreateDeal";
            var sqlSelect = "GetDeal";

            var argumentsInsert = new
            {
                Id = id,
                Name = name,
                CustomerId = customerId,
                VinCode = vinCode,
                CarId = carId,
                DealType = dealType,
                Price = price
            };

            var argumentsSelect = new
            {
                dealId = id.ToString().ToUpper()
            };

            SqlConnection connection = DapperContext.OpenConnection(connectionString);

            await connection.ExecuteAsync(sqlInsert, argumentsInsert);

            IEnumerable<Deal> deals = await connection.QueryAsync<Deal>(sqlSelect, argumentsSelect); 

            DapperContext.CloseConnection(connection);

            Deal deal = deals.SingleOrDefault();

            var dealDto = new DealDto
            {
                Id = deal.Id,
                Name = deal.Name,
                CustomerId = deal.CustomerId,
                VinCode = deal.VinCode,
                CarId = deal.CarId,
                DealType = deal.DealType,
                Price = deal.Price
            };

            return dealDto;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    // RETRIVE

    public async Task<DealDto> GetDealByIdAsync(string connectionString, string dealId)
    {
        var sqlSelect = "GetDeal";

        dealId = dealId.ToUpper();

        var arguments = new
        {
            dealId
        };

        SqlConnection connection = DapperContext.OpenConnection(connectionString);

        IEnumerable<Deal> deals = await connection.QueryAsync<Deal>(sqlSelect, arguments);

        DapperContext.CloseConnection(connection);

        Deal deal = deals.FirstOrDefault();

        var dealDto = new DealDto
        {
            Id = deal.Id,
            Name = deal.Name,
            CustomerId = deal.CustomerId,
            VinCode = deal.VinCode,
            CarId = deal.CarId,
            DealType = deal.DealType,
            Price = deal.Price
        };

        return dealDto;
    }

    public Deal ChooseDealFromList(List<Deal> deals, int index)
    {
        Validator.CheckNull(deals);
        IndexValidator.ValidateIndexOfList(deals, index);

        Deal deal = deals[index];

        Validator.CheckNull(deal);

        return deal;
    }

    public Deal ChooseDealFromList(List<Deal> deals, string name, string customerId)
    {
        Validator.CheckNull(deals);
        NameValidator.CheckNullEmpty(name, customerId);

        Deal deal = deals.Find(x => (x.Name.Contains(name) && x.CustomerId.Contains(customerId)));

        Validator.CheckNull(deal);

        return deal;
    }

    public Deal ChooseDealFromList(List<Deal> deals, Guid id)
    {
        Validator.CheckNull(deals);

        Deal deal = deals.Find(x => (x.Id.CompareTo(id) == 0));

        Validator.CheckNull(deal);

        return deal;
    }

    // UPDATE

    public void AddDealInToList(List<Deal?> deals, Deal deal)
    {
        Validator.CheckNull(deals);
        Validator.CheckNull(deal);

        deals.Add(deal);
    }

    // DELETE

    public void DeleteDealFromList(List<Deal?> deals, int index)
    {
        Validator.CheckNull(deals);
        IndexValidator.ValidateIndexOfList(deals, index);

        deals.RemoveAt(index);
    }

    public void DeleteDealFromList(List<Deal?> deals, string name, string customerId)
    {
        Validator.CheckNull(deals);
        NameValidator.CheckNullEmpty(name, customerId);

        int index = deals.IndexOf(deals.Find(x => (x.Name.Contains(name) && x.CustomerId.Contains(customerId))));

        deals.RemoveAt(index);
    }

    // MOVE IT INTO A SEPARATE MANAGER. 'CRUD'-OPERATIONS SHOULD BE INSTEAD. (YPARKHOMENKO)

    /*private string fileName;
    private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    
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
    }*/

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

    /* public Dictionary<int, Tuple<string, string, string, float, DateTime>> GetAllDealsDict()
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

     }*/
}
