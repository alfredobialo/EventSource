using System;
using System.Threading.Tasks;
using CacheServerCore;
using CacheServerCore.Domain.crm;
using CacheServerCore.Domain.orders;
using Xunit;

namespace CacheServerCoreTest;

public class UnitTest1
{
    private readonly AsomRedisLib _redisLib;

    public UnitTest1()
    {
        _redisLib = new AsomRedisLib();
    }

    [Theory]
    [InlineData("demo1", "Alfred Obialo")]
    [InlineData("demo2", "Christian Juwe")]
    [InlineData("demo3", "Goodness Raven")]
    public async Task Test1(string key, string data)
    {
        var res = await _redisLib.AddItem(key, data, TimeSpan.FromMinutes(60));
        Assert.True(res); // Added if true

        var cacheData = await _redisLib.GetItem(key);
        Assert.Equal(data, cacheData.ToString());
    }

    [Fact]
    public async Task Test2()
    {
        Customer cus = new Customer()
        {
            Id = "cus-001", Name = "Esther Egwe",
            ContactAddress = new AddressInfo()
            {
                City = "Badore",
                Province = "Ajah",
                State = "Lagos",
                ZipCode = "00238"
            }
        };

        SalesOrder so = new SalesOrder()
        {
            Customer =  cus,
            Id = "SO-0001",
            SalesDate = DateTime.Now,
        };

        var res = await _redisLib.AddItem(so.Id, so, TimeSpan.FromHours(2));
        Assert.True(res); // Added if true

        var data = await _redisLib.GetItem<SalesOrder>(so.Id);

        Assert.Equal(data.Customer.Id , so.Customer.Id);

    }
}
