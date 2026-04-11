using UnityEngine;

namespace UI.Extensions
{
    public static class RectTransformExtensions
    {
        public static RectTransform RectTransform(this Transform transform)
        {
            if (transform is RectTransform rectTransform)
            {
                return rectTransform;
            }
            
            return null;
        }
    }
}