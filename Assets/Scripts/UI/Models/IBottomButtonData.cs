using Game.Content;
using UnityEngine;

namespace UI.Models
{
    public interface IBottomButtonData
    {
        Content TargetContent { get; }
        Sprite Icon { get; }
    }
}