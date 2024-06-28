using Screpts.UI;
using VContainer;

public class Observer
{
    private CounterClick _counterClick;
    private UpgradePowerClick _upgradePowerClick;

    [Inject]
    public void Injectdependencies(CounterClick counterClick,UpgradePowerClick upgradePowerClick)
    {
        _counterClick = counterClick;
        _upgradePowerClick = upgradePowerClick;
    }
}
