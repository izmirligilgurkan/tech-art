using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class TopBarController : MonoBehaviour
    {
        [SerializeField] private TopBarData topBarData;
        [SerializeField] private TopBarView topBarView;

        private void Awake()
        {
            if (topBarData == null)
            {
                Debug.LogError("TopBarController: Data is not assigned.");
                return;
            }

            if (topBarView == null)
            {
                Debug.LogError("TopBarController: TopBarView is not assigned.");
                return;
            }

            topBarView.Bind(topBarData);
        }
    }
}