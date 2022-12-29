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

public class WalletAccount
{
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
