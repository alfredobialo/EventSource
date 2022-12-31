using System.Collections.Immutable;
using System.Collections.ObjectModel;
using itrex.businessObjects.model.core;

namespace zedcrest.wallet.core.models;

public class WalletAccountRequest  : IWalletAccountRequest
{
    private Dictionary<string, Wallet> _wallets = new Dictionary<string, Wallet>();
    public WalletUser? Owner { get; internal set; }
    public DateTimeOffset DateCreated { get; set; }

    public ReadOnlyCollection<Wallet> Wallets => new(_wallets.Values.ToList());

    public void Add(Wallet wallet)
    {
        _wallets.Add(wallet.Key, wallet);
    }
}

public interface IWalletAccountRequest
{
    void Add(Wallet walletCurrency);
    ReadOnlyCollection<Wallet> Wallets { get; }
    WalletUser Owner { get; }
}

public class Wallet : WalletBase
{
    public Wallet(string currency)
    {
        Currency = currency;
        Id = $"{Currency.ToLower()}-wallet-{NewId()}";
    }
    public string Currency { get; set; }
    public decimal Balance { get; set; }
}

public class WalletBuilder
{
    private WalletUser wuser = null;
    private Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();
    public IWalletAccountRequest Build()
    {
        WalletAccountRequest wacc = new WalletAccountRequest();
        wacc.Owner = wuser;
        foreach (var wallet in wallets)
        {
            wacc.Add(wallet.Value);
        }
        return wacc;
    }

    public WalletBuilder CreateWallet(WalletUser user)
    {
        this.wuser = user;
        return this;
    }

    public WalletBuilder AddUsdWallet()
    {
        // Uses default WalletFactory. Create USD wallet with $10 as Beginning Balance
       _createAndAddWallet(KnownCurrency.USD, 10.00m);
        
        return this;
    }

    public WalletBuilder AddNgnWallet()
    { 
        // Uses default WalletFactory. Create NGN wallet with 0.00 as Beginning Balance
            _createAndAddWallet();
        return this;
    }
    public WalletBuilder AddWallet(string currency)
    { 
        // Uses default WalletFactory. Create NGN wallet with 0.00 as Beginning Balance
            _createAndAddWallet(currency);
        return this;
    }

    void _createAndAddWallet(string currency = KnownCurrency.NGN, decimal bal = 0.00m)
    {
        Wallet usdWallet = WalletFactory.CreateWalletCurrency(currency, bal);
        
        // check if a wallet with the same Identity has not Been created
        if(!wallets.ContainsKey(currency))
            wallets.Add(currency, usdWallet);
    }
}

public class WalletFactory
{
    public static Wallet CreateWalletCurrency(string currency = KnownCurrency.NGN, decimal bal = 0.00m)
    {
        bal = bal < 0 ? 0 : bal;
        
        // validate Currency : 
        
        return new Wallet(currency)
        { 
            Balance = bal
        };
    }
}

public class KnownCurrency
{
    public const string USD = nameof(USD);
    public const string NGN = nameof(NGN);
    public const string GBP = nameof(GBP);
    public const string EUR = nameof(EUR);
    public const string KES = nameof(KES);
}

public class WalletBase : EntityBase
{
    public static string NewId()
    {
        string id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        id = id.Substring(0, 4) + id.Substring(7, 8);
        return id;
    }
}
