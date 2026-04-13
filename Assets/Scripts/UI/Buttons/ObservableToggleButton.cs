﻿using System;
using Core.Observable;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class ObservableToggleButton : AButton, IDisposable
    {
        [SerializeField] private Image onImage;
        [SerializeField] private Image offImage;
        
        private ScriptableObservableBoolean _observable;
        
        public void Bind(ScriptableObservableBoolean observable)
        {
            _observable = observable;
            _observable.Subscribe(UpdateVisuals);
            UpdateVisuals(_observable.Value);
        }
        
        private void OnDestroy()
        {
            Unsubscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (_observable != null)
            {
                _observable.Unsubscribe(UpdateVisuals);
                _observable = null;
            }
        }

        public void UpdateVisuals(bool isOn)
        {
            if (onImage != null)
            {
                onImage.gameObject.SetActive(isOn);
            }
            
            if (offImage != null)
            {
                offImage.gameObject.SetActive(!isOn);
            }
        }

        protected override void OnButtonClicked()
        {
            if (_observable != null)
            {
                _observable.Set(!_observable.Value);
            }
        }
    }
}