﻿using System;
using DG.Tweening;
using Game.PickerSystem.Controllers;
using Game.PlatformSystem.CheckPointControllers;
using UnityEngine;
using Utils;

namespace Game.PlatformSystem.Base
{
    public class CheckPoint : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.CHECKPOINT;
        public int Target = 3;

        private CheckPointCounterPlatform _checkPointCounterPlatform;
        private Transform _gate1;
        private Transform _gate2;

        private void Awake()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _checkPointCounterPlatform = GetComponentInChildren<CheckPointCounterPlatform>();
            _gate1 = transform.Find("Gate1");
            _gate2 = transform.Find("Gate2");
            _checkPointCounterPlatform.Initialize(Target);
        }

        private void CheckContinue()
        {
            if (_checkPointCounterPlatform.GetCounter() > Target)
            {
                Debug.Log("CheckPoint!");
                _checkPointCounterPlatform.SuccesfulAction();
                _gate1.transform.DORotate(new Vector3(-60,90,90), 1f);
                _gate2.transform.DORotate(new Vector3(60,90,90), 1f);
            }
            else
            {
                Debug.Log("Fail");
            }

            
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerPhysicsController>();
            if (picker != null)
            {
                picker.PushCollectables();
                Timer.Instance.TimerWait(2f, CheckContinue);
            }
        }
    }
}
