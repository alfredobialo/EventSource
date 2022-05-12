using System.Text;
using Newtonsoft.Json;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public class FileDataStoreManager<TData> where TData : EntityBase
{
    private readonly string _fileName;
    Dictionary<string, TData>? lst = new Dictionary<string, TData>(); 
    string path = "";
    public FileDataStoreManager(string fileName)
    {
        _fileName = fileName ?? DateTime.Now.Ticks.ToString();
        path = Path.Combine("Data", _fileName);
    }

    private async Task CreateDbFile()
    {
       
        if (!Directory.Exists(Path.Combine("Data")))
        {
            Directory.CreateDirectory(Path.Combine("Data"));
        }

        bool fileExist = File.Exists(path);
        if (!fileExist)
        {
            var streamWriter = File.CreateText(path);
            await streamWriter.WriteAsync(JsonConvert.SerializeObject(lst));
            await streamWriter.FlushAsync();
            streamWriter.Close();
        }
    }
    
    internal async Task<CommandResponse> AddNewItem(TData obj)
    {
        await CreateDbFile();
        var content = await readFileContent();
        lst = JsonConvert.DeserializeObject<Dictionary<string, TData>>(content);
        // check if user Exist
        if (!lst.ContainsKey(obj.Id))
        {
            lst.Add(obj.Id, obj);
            var streamWriter = File.CreateText(path);
            await streamWriter.WriteAsync(JsonConvert.SerializeObject(lst));
            await streamWriter.FlushAsync();
            streamWriter.Close();
            return CommandResponse.Successful("User Created Succefully");
        }
        return CommandResponse.Failure($"Record with Id : {obj.Id} already Exist");
    }

    private async Task<string> readFileContent()
    {
        var dataStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        byte[] fileByte = new byte[dataStream.Length];
        await dataStream.ReadAsync(fileByte);
        string content = UTF8Encoding.UTF8.GetString(fileByte);
        dataStream.Close();
        return content;
    }
}
