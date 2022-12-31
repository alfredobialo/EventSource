using FluentAssertions;
using Xunit.Abstractions;
using zedcrest.wallet.core.models;

namespace zedcrest.test.tdd.core;

public class WalletTest
{
    private readonly ITestOutputHelper _writer;

    public WalletTest(ITestOutputHelper writer)
    {
        _writer = writer;
    }

    [Fact]
    public void Define_Wallet_With_DefaultUser()
    {
        // arrange

        WalletBuilder builder = new WalletBuilder()
                .CreateWallet(new WalletUser(){Name = "Alfred", Id = "alfred-wallet-2022"})
                .AddUsdWallet()
                .AddNgnWallet() // we can't have the same wallet entity
            ;

        // act : on it
        IWalletAccountRequest walletAccount = builder.Build();

        printWalletDetails(walletAccount);
        // assert
        walletAccount.Should().NotBeNull();
        walletAccount.Wallets.Should().NotContainNulls(x => x.Key);
    }

    [Fact(DisplayName ="Process WalletAccountRequest")]
    public async Task Process_WalletAccountRequest_Should_Pass()
    {
        // arrange
        // build a wallet Request Object
        //WalletAccountRequest war = new WalletAccountRequest();
        //act

        //assert
    }
    
    

    private void printWalletDetails(IWalletAccountRequest wa)
    {
        _writer.WriteLine($"=================== WALLET ACCOUNT {wa.Key}===================\n");
        _writer.WriteLine($"User Details: {wa.Owner?.Name,15}, {wa.Owner.Key,10}\n");
        _writer.WriteLine($"============== WALLETS {wa.Wallets.Count} ===============");
        foreach (var w in wa.Wallets)
        {
            _writer.WriteLine($"======= WALLET Type {w.Currency} ====  Avail Bal : {w.Balance:N2}\n" +
                $"Id: {w.Key,-15} AccountID : {w.AccountId}");
        }
    }
}
