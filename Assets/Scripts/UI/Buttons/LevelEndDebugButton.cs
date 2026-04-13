using Game.Currency;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Buttons
{
    public class LevelEndDebugButton : AButton
    {
        [SerializeField] private LevelEndViewData data;
        [SerializeField] private LevelEndView levelEndView;
        
        protected override void OnButtonClicked()
        {
            levelEndView.Bind(data);
            levelEndView.Show();
        }
    }
}