using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using S = System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maze.Player
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(CharacterController))]
	public class FirstPersonCharacter : Character, ITargetOffsetProvider
	{
		#region Private variables
		private CharacterController characterController = null;
		[Header("Movement")]
		[SerializeField]
		[Min(0.1f)]
		[Tooltip("Move speed in m/s")]
		private float moveSpeed = 2.5f;
		[Header("Turn")]
		[SerializeField]
		[Min(0.0f)]
		[Tooltip("Time to align to the current view point. Set to 0 for instant alignment.")]
		private float orientToViewTime = 0.0f;
		private float viewPointAlignmentSpeed = 0.0f;
		[Min(0.0f)]
		[SerializeField]
		[Tooltip("Do not orient if the target is this below value in degrees from the current orientation")]
		private float orientTreshold = 1.5f;
		[Header("View")]
		[SerializeField]
		private Vector3 _targetOffset = Vector3.up * 0.85f;
		#endregion
		#region Public properties
		public Vector3 targetOffset => _targetOffset;
		#endregion
		#region Lifecycle
		void Awake()
		{
			characterController = GetComponent<CharacterController>();
		}
		void Update()
		{
			AlignToViewPoint();
			ApplyGravity();
		}
		#endregion
		#region Public methods
		public override void Move(Vector3 moveWorldDirection) => MoveBy(moveWorldDirection * moveSpeed * Time.deltaTime);
		public override void MoveBy(Vector3 worldOffset)
		{
			if(characterController.enabled)
				characterController.Move(worldOffset);
		}
		public override void Teleport(Vector3 position, Quaternion rotation)
		{
			characterController.enabled = false;

			transform.position = position;
			transform.rotation = rotation;

			characterController.enabled = true;

			if(viewPoint != null)
				viewPoint.AlignTo(transform);
		}
		#endregion
		#region Private methods
		private void AlignToViewPoint()
		{
			if(viewPoint == null)
				return;

			//	Caluclate orientation limits
			float currentAngle = transform.eulerAngles.y;
			float targetAngle = viewPoint.transform.eulerAngles.y;

			//	Check if it is a hard orient
			bool hardOrient = Mathf.Approximately(orientToViewTime, 0.0f);

			//	Prepare target euler angles
			Vector3 targetEulerAngles = transform.eulerAngles;

			//	Handle orient based on the mode
			if(hardOrient)
			{
				// Do not orient if already there
				if(Mathf.Approximately(currentAngle, targetAngle))
					return;

				targetEulerAngles.y = targetAngle;
			}
			else
			{
				//	Only orient if above the orient treshold
				if(Mathf.Abs(currentAngle - targetAngle) < orientTreshold)
					return;

				targetEulerAngles.y = Mathf.SmoothDampAngle(
					currentAngle,
					targetAngle,
					ref viewPointAlignmentSpeed,
					orientToViewTime
				);
			}

			//	Apply rotation
			transform.eulerAngles = targetEulerAngles;
		}
		private void ApplyGravity()
		{
			if(characterController.enabled)
				characterController.Move(Physics.gravity * Time.deltaTime);
		}
		#endregion
	}
}
