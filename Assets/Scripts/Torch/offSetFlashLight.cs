using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offSetflashlight : MonoBehaviour
{
    #region Public Variables
    [Range(0f, 5f)]
    public float speed = 1.0f;
    #endregion
    #region Private Variables
    [SerializeField]
    private Transform goFollow;
    private Vector3 vectorOffSet;
    #endregion
    #region Lifecycle
    private void Start()
    {
        vectorOffSet = transform.position-goFollow.transform.position;
    }
    private void Update()
    {
        transform.position = goFollow.transform.position + vectorOffSet;
        transform.rotation = Quaternion.Slerp(transform.rotation,goFollow.transform.rotation,speed*Time.deltaTime);
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    #endregion
}
