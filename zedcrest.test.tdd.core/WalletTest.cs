using zedcrest.wallet.core.models;

namespace zedcrest.test.tdd.core;

public class WalletTest
{
    [Fact]
    public void Define_Wallet_With_DefaultUser()
    {
        // arrange

        WalletBuilder builder = new WalletBuilder()
            .CreateWallet(WalletUser.New())
            .AddUsdWallet()
            .AddNgnWallet()   // we can't have the same wallet entity
           ;
        WalletAccount walletAccount = builder.Build();
        // act : on it

        
        
        
        // assert
    }
}

public class WalletAccount  : IWalletAccount
{
    private Dictionary<string, WalletAccount> _walletAccounts = new Dictionary<string, WalletAccount>();
    public WalletUser Owner { get; internal set; }
    public DateTimeOffset DateCreated { get; set; }

    public void Add(WalletCurrency walletCurrency)
    {
    }
}

public interface IWalletAccount
{
    void Add(WalletCurrency walletCurrency);

}

public class WalletCurrency
{
    public string Cur { get; set; }
    public decimal Bal { get; set; }
}

public class WalletBuilder
{
    public WalletAccount Build()
    {
        return null;
    }

    public WalletBuilder CreateWallet(WalletUser @new)
    {
        return null;
    }

    public WalletBuilder AddUsdWallet()
    {
        return null;
    }

    public WalletBuilder AddNgnWallet()
    {
        return null;
    }
}
