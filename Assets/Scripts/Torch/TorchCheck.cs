using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchCheck : MonoBehaviour
{

    [SerializeField]
    public GameObject SpotLight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("la torcia è stata presa");
            SpotLight.SetActive(true);
            Destroy(gameObject);
        }
    }
}
