using UnityEngine;

namespace Game.Content
{
    [CreateAssetMenu(fileName = "Content_", menuName = "Game/Content", order = 0)]
    public class Content : ScriptableObject
    {
        [SerializeField] private bool isUnlocked;
        [SerializeField] private string contentName;
        
        public bool IsUnlocked => isUnlocked;
        public string ContentName => contentName; // If needed, this can be changed to a localized string or something similar.
    }
}