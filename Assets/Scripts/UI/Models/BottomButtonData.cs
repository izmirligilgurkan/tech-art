using Game.Content;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "BottomButton_", menuName = "Game/UI/Buttons/BottomButton", order = 0)]
    public class BottomButtonData : ScriptableObject, IBottomButtonData
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private Content targetContent;

        public Content TargetContent => targetContent;
        public Sprite Icon => icon;
    }
}