using System;
using AssetKits.ParticleImage;
using Core.Pooling;
using Core.Provider;
using UnityEngine;

namespace UI.Particles
{
    public class CurrencyParticleProvider : MonoBehaviour, IProvider
    {
        private const int MaxParticleRate = 100;
        
        [SerializeField] private ParticleImage currencyParticlePrefab;
        [SerializeField] private Transform attractorTargetPrefab;
        
        private Pooler<ParticleImage> _currencyParticlePool;
        private Pooler<Transform> _attractorTargetPool;
        
        private void Awake()
        {
            _currencyParticlePool = new Pooler<ParticleImage>(currencyParticlePrefab, transform, 10);
            _attractorTargetPool = new Pooler<Transform>(attractorTargetPrefab, transform, 10);
            
            ProviderService.Register<CurrencyParticleProvider>(this);
        }

        private void OnDestroy()
        {
            _currencyParticlePool?.Dispose();
            _attractorTargetPool?.Dispose();
            
            ProviderService.Unregister<CurrencyParticleProvider>();
        }

        public void SpawnCurrencyParticles(UIParticleData data, Action onComplete = null)
        {
            ParticleImage particle = _currencyParticlePool.Get();
            Transform target = _attractorTargetPool.Get();
            
            particle.transform.position = data.StartPosition;
            target.position = data.EndPosition;
            particle.attractorEnabled = true;
            particle.attractorTarget = target;
            
            particle.sprite = data.Graphic;
            particle.rateOverLifetime = Mathf.Clamp(data.Count, 1, MaxParticleRate);
            particle.onLastParticleFinished.AddListener(() =>
            {
                onComplete?.Invoke();
                particle.onLastParticleFinished.RemoveAllListeners();
                _currencyParticlePool.Return(particle);
                _attractorTargetPool.Return(target);
            });
            
            particle.Play();
        }
    }
}