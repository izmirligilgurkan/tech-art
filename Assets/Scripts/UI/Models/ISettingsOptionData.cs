using Core.Observable;
using UnityEngine;

namespace UI.Models
{
    public interface ISettingsOptionData
    {
        string Title { get; }
        Sprite Icon { get; }
    }
}