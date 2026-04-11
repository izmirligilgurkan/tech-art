using UnityEngine;

namespace UI.Particles
{
    public struct UIParticleData
    {
        public readonly Sprite Graphic;
        public readonly int Count;
        public readonly Vector2 StartPosition;
        public readonly Vector2 EndPosition;
        
        public UIParticleData(Sprite graphic, int count, Vector2 startPosition, Vector2 endPosition)
        {
            Graphic = graphic;
            Count = count;
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}