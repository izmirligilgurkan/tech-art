using System.Collections.Generic;
using DG.Tweening;
using Game.Currency;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class RewardCell : MonoBehaviour
    {
        [SerializeField] private Image rewardIcon;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private List<DOTweenAnimation> showAnimations;
        
        public void Bind(CurrencyReward reward, bool isBonus = false)
        {
            rewardIcon.sprite = reward.currency.Icon;
            var text = isBonus? "+" : "";
            text += reward.amount.ToString();
            amountText.text = text;
        }

        public void PlayShowAnimations()
        {
            foreach (var anim in showAnimations)
            {
                anim?.DORestart();
            }
        }
    }
}