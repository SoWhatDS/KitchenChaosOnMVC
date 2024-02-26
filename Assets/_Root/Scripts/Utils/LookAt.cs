using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.Utils
{
    internal sealed class LookAt : MonoBehaviour
    {
        private enum Mode
        {
            LookAt,
            LookAtInverted,
            CameraForward,
            CameraForwardInverted
        }

        [SerializeField] private Mode _mode;

        private void LateUpdate()
        {
            CheckModeCamera();
        }

        private void CheckModeCamera()
        {
            switch (_mode)
            {
                case Mode.LookAt:
                    transform.LookAt(Camera.main.transform);
                    break;
                case Mode.LookAtInverted:
                    Vector3 directionFromCamera = transform.position - Camera.main.transform.position;
                    transform.LookAt(transform.position + directionFromCamera);
                    break;
                case Mode.CameraForward:
                    transform.forward = Camera.main.transform.forward;
                    break;
                case Mode.CameraForwardInverted:
                    transform.forward -= Camera.main.transform.forward;
                    break;

            }
        }
    }
}
