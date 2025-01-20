using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class PickUpPlayer : MonoBehaviour
    {
        [SerializeField]
        private Camera PlayerCamera;
        [SerializeField]
        private LayerMask pickUpLayerMask;
        [SerializeField]
        private float pickUpRange;
        [SerializeField]
        private Transform Hand;

        private Rigidbody CurrentRigibody;
        private Collider CurrentCollider;

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Ray Pickupray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
                if (Physics.Raycast(Pickupray, out RaycastHit hitInfo, pickUpRange, pickUpLayerMask))
                {
                    if (CurrentRigibody)
                    {
                        
                    }
                    else
                    {
                       
                        CurrentRigibody = hitInfo.rigidbody;
                        CurrentCollider = hitInfo.collider;
                    }
                }
            }
            if (CurrentRigibody)
            {
                CurrentRigibody.position = Hand.position;
                CurrentRigibody.rotation = Hand.rotation;
            }
        }
    }
}
