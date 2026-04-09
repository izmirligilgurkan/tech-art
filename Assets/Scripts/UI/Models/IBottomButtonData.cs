using UnityEngine;
using UnityEngine.UI;

namespace UI.Models
{
    public interface IBottomButtonData
    {
        Content TargetContent { get; }
        Sprite Icon { get; }
    }
}