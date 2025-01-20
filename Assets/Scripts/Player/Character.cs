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
	public abstract class Character : MonoBehaviour
	{
		#region Public variables
		[S.NonSerialized]
		public ViewPoint viewPoint = null;
		#endregion
		#region Public methods
		public abstract void Move(Vector3 moveWorldDirection);
		public abstract void MoveBy(Vector3 worldOffset);
		public void Teleport(Transform point, bool usePointRotation = true)
		{
			if(usePointRotation)
				Teleport(point.position, point.rotation);
			else
				Teleport(point.position);
		}
		public void Teleport(Vector3 position) => Teleport(position, transform.rotation);
		public abstract void Teleport(Vector3 position, Quaternion rotation);
		#endregion
	}
}
