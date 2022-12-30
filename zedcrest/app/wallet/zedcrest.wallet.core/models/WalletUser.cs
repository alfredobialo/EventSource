using itrex.businessObjects.model.core;

namespace zedcrest.wallet.core.models;

public class WalletUser :WalletBase
{
    public static WalletUser New()
    {
        return new WalletUser() {Id = $"user-{NewId()}".ToString()};
    }
}
