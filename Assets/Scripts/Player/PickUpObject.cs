using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class PickUpObject : MonoBehaviour
    {
        private Rigidbody objectRigidbody;
        private Transform objectGrabTransform;


        private void Awake()
        {
            objectRigidbody = GetComponent<Rigidbody>();
        }

        public void Grab(Transform objectGrabTransform)
        {
            this.objectGrabTransform = objectGrabTransform;
            objectRigidbody.useGravity = false;
        }

        public void Drop()
        {
            this.objectGrabTransform = null;
            objectRigidbody.useGravity = false;
        }

        private void FixedUpdate()
        {
            if (objectGrabTransform != null)
            {
                float lerpSpeed = 10f;
                Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabTransform.position, Time.deltaTime * lerpSpeed);
                objectRigidbody.MovePosition(newPosition);
            }
        }
    }
}

