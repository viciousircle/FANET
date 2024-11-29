using System;
using WebApplication2.Models;
using Newtonsoft.Json;


namespace WebApplication2.Services;

public class UAVData
{
    public List<UAV> LoadUAVsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UAV>>(json);
        }
        else
        {
            throw new FileNotFoundException("File not found", filePath);
        }
    }

}
