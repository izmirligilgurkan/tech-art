using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace UI.Buttons
{
    public class SimpleButtonWithAnimation : SimpleButton
    {
        [SerializeField] private List<DOTweenAnimation> animationsToPlay;

        public void PlayAnimations() 
        {
            foreach (var anim in animationsToPlay)
            {
                anim.DORestart();
            }
        }
    }
}