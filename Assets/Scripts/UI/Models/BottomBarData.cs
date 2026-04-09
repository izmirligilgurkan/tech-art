using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "BottomBar_", menuName = "Game/UI/Buttons/BottomBar", order = 0)]
    public class BottomBarData : ScriptableObject, IBottomBarData
    {
        [SerializeField] private List<BottomButtonData> buttons;
        
        public IReadOnlyList<IBottomButtonData> Buttons => buttons;
    }
}