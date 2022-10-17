using Newtonsoft.Json.Serialization;

namespace UserManagement.core.extensions;
using Newtonsoft.Json;
public static class BaseObjectExtension
{
    public static string ToJson(this object obj,bool prettyPrint = false, bool useSnakeCase = false)
    {
        var jsonSettings = new JsonSerializerSettings()
        {
            ContractResolver =  new CamelCasePropertyNamesContractResolver()
            {
                NamingStrategy = useSnakeCase ? new SnakeCaseNamingStrategy() : new CamelCaseNamingStrategy() 
            },
            Formatting = prettyPrint ? Formatting.Indented : Formatting.None,
            
        };
        
        var result = JsonConvert.SerializeObject(obj, jsonSettings);
        return result;
    }
}
