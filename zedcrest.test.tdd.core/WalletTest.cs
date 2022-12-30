using FluentAssertions;
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
      
        // act : on it
          IWalletAccount walletAccount = builder.Build();
        
        
        // assert
        walletAccount.Should().NotBeNull();

    }
}

