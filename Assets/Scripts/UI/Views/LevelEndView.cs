using System;
using System.Collections.Generic;
using AssetKits.ParticleImage;
using Core.Provider;
using DG.Tweening;
using UI.Buttons;
using UI.Models;
using UI.Particles;
using UnityEngine;

namespace UI.Views
{
    public class LevelEndView : AView
    {
        [SerializeField] private RewardCell bigRewardCell;
        [SerializeField] private List<RewardCell> smallRewardViews;
        [SerializeField] private RewardCell bonusRewardCell;
        [SerializeField] private SimpleButton homeButton;
        [SerializeField] private SimpleButton rewardedBonusButton;
        [SerializeField] private List<RectTransform> sparkleAreas;

        private ILevelEndViewData _levelEndViewData;
        private bool _isBonusClaimed;
        private List<ParticleImage> _spawnedParticles = new();
        
        private void Awake()
        {
            homeButton.OnClicked += OnHomeButtonClicked;
            rewardedBonusButton.OnClicked += OnRewardedBonusButtonClicked;
        }

        private void OnRewardedBonusButtonClicked()
        {
            _isBonusClaimed = true;
        }

        public override void Show()
        {
            base.Show();
            PlayShowAnimation(SpawnParticles);
        }

        public override void Hide()
        {
            DestroyParticles();
            PlayHideAnimation(base.Hide);
        }
        
        private void PlayShowAnimation(TweenCallback onComplete = null)
        {
            transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnComplete(onComplete);
        }
        
        private void PlayHideAnimation(TweenCallback onComplete = null)
        {
            transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(onComplete);
        }
        
        private void SpawnParticles()
        {
            var provider = ProviderService.Get<SparkleParticleProvider>();
            foreach (var area in sparkleAreas)
            {
                var corners = new Vector3[4];
                area.GetWorldCorners(corners);
                var center = (corners[0] + corners[2]) / 2f;
                var spawnSparkleEffect = provider.SpawnSparkleEffect(center, area.rect);
                _spawnedParticles.Add(spawnSparkleEffect);
            }
        }
        
        private void DestroyParticles()
        {
            foreach (var particle in _spawnedParticles)
            {
                particle.Stop();
                Destroy(particle.gameObject);
            }
            
            _spawnedParticles.Clear();
        }

        private void OnHomeButtonClicked()
        {
            Hide();
            ProcessRewards();
        }

        private void ProcessRewards()
        {
            _levelEndViewData.BigReward.ProcessReward();
            foreach (var smallReward in _levelEndViewData.SmallRewards)
            {
                smallReward.ProcessReward();
            }

            if (_isBonusClaimed)
            {
                _levelEndViewData.RewardedBonus.ProcessReward();   
            }
        }

        public void Bind(ILevelEndViewData data)
        {
            _levelEndViewData = data;
            _isBonusClaimed = false;
            
            bigRewardCell.Bind(data.BigReward);
            
            for (int i = 0; i < smallRewardViews.Count; i++)
            {
                if (i < data.SmallRewards.Count)
                {
                    smallRewardViews[i].Bind(data.SmallRewards[i]);
                    smallRewardViews[i].gameObject.SetActive(true);
                }
                else
                {
                    smallRewardViews[i].gameObject.SetActive(false);
                }
            }
            
            bonusRewardCell.Bind(data.RewardedBonus, true);
        }
    }
}