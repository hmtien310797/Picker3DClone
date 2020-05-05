﻿using System;
using UnityEngine;
using Utils;

namespace Game.PickerSystem.Controllers
{
    public class PickerInputController : MonoBehaviour
    {
        public Action<float> OnMousePressing;
        public Action OnMouseReleasing;

        private Camera _pickerCamera;
        private Vector3 _mousePos;
        private float _distanceToScreen;

        public void Initialize(Camera cam)
        {
            _pickerCamera = cam;
        }
        
        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                var position = Input.mousePosition;
                if (position.x > 0 && position.x < Screen.width)
                {
                    _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
                    _mousePos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen ));
                    
                    OnMousePressing.SafeInvoke(_mousePos.x);
                }
            }
            
            OnMouseReleasing.SafeInvoke();
        }
    }
}
