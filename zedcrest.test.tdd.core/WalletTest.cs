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
                .CreateWallet(WalletUser.New())
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

    private void printWalletDetails(IWalletAccountRequest wa)
    {
        _writer.WriteLine("=================== WALLET ACCOUNT ===================\n");
        _writer.WriteLine($"User Details: {wa.Owner?.Name,15}, {wa.Owner.Key,10}\n");
        _writer.WriteLine($"============== WALLETS {wa.Wallets.Count} ===============");
        foreach (var w in wa.Wallets)
        {
            _writer.WriteLine($"======= WALLET Type {w.Currency} ====  Avail Bal : {w.Balance:N2}, id: {w.Key,10}=====");
        }
    }
}
