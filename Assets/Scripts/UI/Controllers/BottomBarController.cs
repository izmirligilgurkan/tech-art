using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class BottomBarController : MonoBehaviour
    {
        [SerializeField] private BottomBarData data;
        [SerializeField] private BottomBarView bottomBarView;

        private void Awake()
        {
            if (data == null)
            {
                Debug.LogError("BottomBarController: Data is not assigned.");
                return;
            }
            
            if (bottomBarView == null)
            {
                Debug.LogError("BottomBarController: BottomBarView is not assigned.");
                return;
            }
            
            bottomBarView.Bind(data);
        }
    }
}