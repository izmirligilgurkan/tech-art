using DG.Tweening;
using TMPro;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Buttons
{
    public class BottomButtonSelectedView : AView
    {
        [SerializeField] private TMP_Text contentName;

        private Tween _moveTween;
        
        public void SetUnselected()
        {
            contentName.text = "";
            if (_moveTween != null && _moveTween.IsActive())
            {
                _moveTween.Kill();
            }
            
            Hide();
        }
        public void SetButtonSelected(IBottomButtonData data, Transform anchor)
        {
            Show();
            contentName.text = data.TargetContent.ContentName;
            if (_moveTween != null && _moveTween.IsActive())
            {
                _moveTween.Kill();
            }
            
            transform.SetParent(anchor, true);
            transform.SetAsFirstSibling();
            
            _moveTween = transform.DOLocalMoveX(0f, 0.3f).SetEase(Ease.OutBack);
        }
    }
}