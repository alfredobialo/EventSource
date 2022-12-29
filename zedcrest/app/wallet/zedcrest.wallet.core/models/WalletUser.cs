namespace zedcrest.wallet.core.models;

public record WalletUser
{
    public string Id
    {
        get;
        init;
    }
    public static WalletUser New()
    {
        return new WalletUser() {Id = Guid.NewGuid().ToString()};
    }
}
