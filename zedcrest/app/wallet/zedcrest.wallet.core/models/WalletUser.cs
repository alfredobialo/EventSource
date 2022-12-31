using itrex.businessObjects.model.core;

namespace zedcrest.wallet.core.models;

public class WalletUser :WalletBase
{
    public string Name { get; set; }
    public static WalletUser New()
    {
        return new WalletUser() {Id = $"user-{NewId()}".ToString(), Name = "Demo User"};
    }
}
