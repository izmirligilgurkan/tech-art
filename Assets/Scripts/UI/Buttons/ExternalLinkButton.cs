using System;
using UnityEngine;

namespace UI.Buttons
{
    public class ExternalLinkButton : AButton
    {
        [SerializeField] private string linkAddress;

        private void OnValidate()
        {
            if (!Uri.IsWellFormedUriString(linkAddress, UriKind.Absolute))
            {
                Debug.LogWarning($"The link address '{linkAddress}' is not a valid URL. Please enter a valid URL in the ExternalLinkButton.");
            }
        }

        protected override void OnButtonClicked()
        {
            if (Uri.IsWellFormedUriString(linkAddress, UriKind.Absolute))
            {
                Application.OpenURL(linkAddress);
            }
            else
            {
                Debug.LogError($"Cannot open URL '{linkAddress}' because it is not a valid URL.");
            }
        }
    }
}