using DG.Tweening;
using TMPro;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Buttons
{
    public class BottomButtonSelectedView : AView
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private TMP_Text contentName;

        private Tween _moveTween;
        
        public float Width => rectTransform.rect.width;
        
        public void SetUnselected()
        {
            contentName.text = "";
            if (_moveTween != null && _moveTween.IsActive())
            {
                _moveTween.Kill();
            }
            
            Hide();
        }
        
        public void SetButtonSelected(IBottomButtonData data, RectTransform anchor)
        {
            Show();
            contentName.text = data.TargetContent.ContentName;
            if (_moveTween != null && _moveTween.IsActive())
            {
                _moveTween.Kill();
            }
            
            _moveTween = rectTransform.DOAnchorPosX(anchor.anchoredPosition.x, 0.3f).SetEase(Ease.OutQuad);
        }
    }
}