using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SFX))]
public class SpaceShip : MonoBehaviour
{
    #region Public Variables
    public GameObject text;
    public GameObject credits;
    #endregion
    #region Private Variables
    private bool playerInRange=false;
    private SFX sfx;
    #endregion
    #region Lifecycle
    private void Start()
    {
        sfx = GetComponent<SFX>();
    }
    private void Update()
    {
        Escape();
    }
    #endregion
    #region Public Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            text.SetActive(true);
        }
    }
    private void Escape()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerInRange)
        {
            credits.SetActive(true);
            sfx.PlaySFX(0);
            Time.timeScale = 0.0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
    #endregion
    #region Private Methods
    #endregion
}
