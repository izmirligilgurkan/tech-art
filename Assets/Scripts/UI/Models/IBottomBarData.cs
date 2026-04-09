using System.Collections.Generic;

namespace UI.Models
{
    public interface IBottomBarData
    {
        IReadOnlyList<IBottomButtonData> Buttons { get; }
    }
}