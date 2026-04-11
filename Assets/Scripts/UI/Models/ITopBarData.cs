using System.Collections.Generic;

namespace UI.Models
{
    public interface ITopBarData
    {
        IReadOnlyList<ICurrencyBarData> CurrencyBars { get; }
    }
}