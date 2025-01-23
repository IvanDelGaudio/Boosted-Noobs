using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FirstPersonCamera : MonoBehaviour
    {
        [Header("Focus")]
        public Transform target = null;

        
        public Vector2 mouseSensitivity = Vector2.one;
        public Vector2 padSensitivity = Vector2.one * 75.0f;
        public Vector2 padDrag = Vector2.one * 150.0f;
        private Camera cam = null;

        private float maxUpAngle = 50.0f;
        private float maxDownAngle = -50.0f;
        private float angleAroundVertical = 0.0f;
        private float currentVelocityAroundVertical = 0.0f;
        private float angleAroundRight = 0.0f;
        private float currentVelocityAroundRight = 0.0f;

        private Vector3 moveVelocity = Vector3.zero;
        private Vector3 rotateVelocity = Vector3.zero;
        void Awake()
        {
            cam = GetComponent<Camera>();
        }
        void LateUpdate()
        {

            currentVelocityAroundVertical = Mathf.MoveTowards(currentVelocityAroundVertical, 0, Time.deltaTime * padDrag.x);
            currentVelocityAroundRight = Mathf.MoveTowards(currentVelocityAroundRight, 0, Time.deltaTime * padDrag.y);

            AddRotationAroundVertical(Input.GetAxis("Look Horizontal") * mouseSensitivity.x);
            AddRotationAroundRight(Input.GetAxis("Look Vertical") * mouseSensitivity.y);

            Vector3 lookDirection = Vector3.forward;
            lookDirection = Quaternion.AngleAxis(-angleAroundRight, Vector3.right) * lookDirection;
            lookDirection = Quaternion.AngleAxis(angleAroundVertical, Vector3.up) * lookDirection;
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        }

        private void AddRotationAroundVertical(float degrees)
        {
            angleAroundVertical += degrees;
            angleAroundVertical = (angleAroundVertical + 360) % 360;
        }
        private void AddRotationRateAroundVertical(float degreesPerSecond)
        {

            AddRotationAroundVertical(currentVelocityAroundVertical * Time.deltaTime);
            if (Mathf.Abs(degreesPerSecond) < 0.1f)
                return;
            if (Mathf.Sign(degreesPerSecond) != Mathf.Sign(currentVelocityAroundVertical))
                currentVelocityAroundVertical = degreesPerSecond;
            else
                currentVelocityAroundVertical = Mathf.Sign(degreesPerSecond) * Mathf.Max(Mathf.Abs(currentVelocityAroundVertical), Mathf.Abs(degreesPerSecond));
        }

        private void AddRotationAroundRight(float degrees)
        {
            angleAroundRight += degrees;
            angleAroundRight = Mathf.Clamp(angleAroundRight, maxDownAngle, maxUpAngle);
        }
        private void AddRotationRateAroundRight(float degreesPerSecond)
        {

            AddRotationAroundRight(currentVelocityAroundRight * Time.deltaTime);
            if (Mathf.Abs(degreesPerSecond) < 0.1f)
                return;
            if (Mathf.Sign(degreesPerSecond) != Mathf.Sign(currentVelocityAroundRight))
                currentVelocityAroundRight = degreesPerSecond;
            else
                currentVelocityAroundRight = Mathf.Sign(degreesPerSecond) * Mathf.Max(Mathf.Abs(currentVelocityAroundRight), Mathf.Abs(degreesPerSecond));
        }
    }
