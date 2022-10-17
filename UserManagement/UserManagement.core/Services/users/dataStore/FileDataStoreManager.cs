using System.Text;
using asom.lib.core;
using Newtonsoft.Json;
using UserManagement.core.shared;
using ICriteria = UserManagement.core.shared.ICriteria;

namespace UserManagement.core.Services.users.dataStore;

public class FileDataStoreManager<TData>  where TData : EntityBase
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
        await getFileContent();
        // check if user Exist
        if (!lst.ContainsKey(obj.Id))
        {
            lst.Add(obj.Id, obj);
            await createFileWithData();
            return CommandResponse.Successful("User Created Successfully");
        }

        return CommandResponse.Failure($"Record with Id : {obj.Id} already Exist");
    }
    internal async Task<CommandResponse> DeleteItem(string objId)
    {
        await getFileContent();
        // check if user Exist
        if (lst.ContainsKey(objId))
        {
            lst.Remove(objId);
            await createFileWithData();
            return CommandResponse.Successful("User Deleted Successfully");
        }

        return CommandResponse.Failure($"Record with Id : {objId} Not Found");
    }

    private async Task createFileWithData()
    {
        var streamWriter = File.CreateText(path);
        await streamWriter.WriteAsync(JsonConvert.SerializeObject(lst));
        await streamWriter.FlushAsync();
        streamWriter.Close();
    }

    private async Task getFileContent()
    {
        await CreateDbFile();
        var content = await readFileContent();
        lst = JsonConvert.DeserializeObject<Dictionary<string, TData>>(content);
    }

    internal async Task<CommandResponse<TData>> GetItem(string objId)
    {
        await getFileContent();
        // check if user Exist
        var firstOrDefault = lst.Keys.Any(x => x == objId);
        if (firstOrDefault)
        {
            var data = lst[objId];
            return CommandResponse<TData>.SuccessResponse("User Loaded Successfully", data);
        }

        return CommandResponse<TData>.FailedResponse($"Record with Id : {objId} Not  found");
    }

    internal async Task<CommandResponse<IEnumerable<TData>>> GetItems()
    {
        await getFileContent();
        // check if user Exist
        var data = lst.Values.ToList();
        return CommandResponse<IEnumerable<TData>>.SuccessResponse("All users returned",data );
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
