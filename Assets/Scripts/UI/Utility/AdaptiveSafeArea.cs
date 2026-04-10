using UnityEngine;

namespace UI.Utility
{
    public class AdaptiveSafeArea : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        [Header("Banner Heights (in pixels)")]
        [SerializeField] private float topBannerHeight;
        [SerializeField] private float bottomBannerHeight;

        [Header("Safe Area Settings")]
        [SerializeField] private bool applyTopSafeArea = true;
        [SerializeField] private bool applyBottomSafeArea = true;
        [SerializeField] private bool applyLeftSafeArea = true;
        [SerializeField] private bool applyRightSafeArea = true;

        private Rect _lastSafeArea = Rect.zero;
        private Vector2 _lastScreenSize = Vector2.zero;
        private ScreenOrientation _lastOrientation = ScreenOrientation.AutoRotation;
        private float _lastTopBanner = -1f;
        private float _lastBottomBanner = -1f;

        private void Awake()
        {
            if (rectTransform == null)
                rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            Apply();
        }

        private void Update()
        {
            if (HasChanged())
                Apply();
        }

        private bool HasChanged()
        {
            return Screen.safeArea != _lastSafeArea
                   || new Vector2(Screen.width, Screen.height) != _lastScreenSize
                   || Screen.orientation != _lastOrientation
                   || !Mathf.Approximately(topBannerHeight, _lastTopBanner)
                   || !Mathf.Approximately(bottomBannerHeight, _lastBottomBanner);
        }

        private void Apply()
        {
            if (rectTransform == null)
            {
                rectTransform = GetComponent<RectTransform>();
                if (rectTransform == null) return;
            }

            _lastSafeArea = Screen.safeArea;
            _lastScreenSize = new Vector2(Screen.width, Screen.height);
            _lastOrientation = Screen.orientation;
            _lastTopBanner = topBannerHeight;
            _lastBottomBanner = bottomBannerHeight;

            ApplyToRectTransform(Screen.safeArea);
        }

        private void ApplyToRectTransform(Rect safeArea)
        {
            float screenW = Screen.width;
            float screenH = Screen.height;

            // Clamp safe area to screen bounds
            safeArea.xMin = Mathf.Max(safeArea.xMin, 0);
            safeArea.yMin = Mathf.Max(safeArea.yMin, 0);
            safeArea.xMax = Mathf.Min(safeArea.xMax, screenW);
            safeArea.yMax = Mathf.Min(safeArea.yMax, screenH);

            // Shrink further to account for banner ads
            float effectiveBottom = safeArea.yMin;
            float effectiveTop    = safeArea.yMax;

            if (applyBottomSafeArea)
                effectiveBottom = Mathf.Min(effectiveBottom + bottomBannerHeight, effectiveTop);

            if (applyTopSafeArea)
                effectiveTop = Mathf.Max(effectiveTop - topBannerHeight, effectiveBottom);

            rectTransform.anchorMin = new Vector2(
                applyLeftSafeArea   ? safeArea.xMin    / screenW : 0f,
                applyBottomSafeArea ? effectiveBottom  / screenH : 0f
            );

            rectTransform.anchorMax = new Vector2(
                applyRightSafeArea ? safeArea.xMax  / screenW : 1f,
                applyTopSafeArea   ? effectiveTop   / screenH : 1f
            );

            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }

        /// <summary>
        /// Programmatically update banner heights at runtime (e.g. after an ad loads).
        /// </summary>
        public void SetBannerHeights(float topPixels, float bottomPixels)
        {
            topBannerHeight    = topPixels;
            bottomBannerHeight = bottomPixels;
            Apply();
        }

        /// <summary>Returns the current top banner height in pixels.</summary>
        public float TopBannerHeight    => topBannerHeight;
        /// <summary>Returns the current bottom banner height in pixels.</summary>
        public float BottomBannerHeight => bottomBannerHeight;
    }
}