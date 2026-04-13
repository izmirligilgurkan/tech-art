using AssetKits.ParticleImage;
using Core.Provider;
using UnityEngine;

namespace UI.Particles
{
    public class SparkleParticleProvider : MonoBehaviour, IProvider
    {
        [SerializeField] private ParticleImage sparkleAreaPrefab;
        
        private void Awake()
        {
            ProviderService.Register<SparkleParticleProvider>(this);
        }
        
        private void OnDestroy()
        {
            ProviderService.Unregister<SparkleParticleProvider>();
        }

        public ParticleImage SpawnSparkleEffect(Vector3 position, Rect sparkleArea)
        {
            ParticleImage sparkleEffect = Instantiate(sparkleAreaPrefab, transform);
            sparkleEffect.transform.position = position;
            sparkleEffect.rectWidth = sparkleArea.width;
            sparkleEffect.rectHeight = sparkleArea.height;
            sparkleEffect.Play();
            return sparkleEffect;
        }
    }
}