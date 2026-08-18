using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    #region Public variables
    #endregion

    #region Private variables
    [SerializeField] private List<Collectables> collectables;
    [SerializeField] private Transform player;
    #endregion

    #region Public properties
    #endregion

    #region Private properties
    #endregion

    #region Lifecycle
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        CheckDistance();
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void CheckDistance()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is null. Skipping distance check.");
            return; // Interrompi l'esecuzione se il player non esiste
        }

        for (int i = collectables.Count - 1; i >= 0; i--)
        {
            if (collectables[i] != null && collectables[i].CheckDistance(player))
            {
                collectables.RemoveAt(i); // Rimuovi l'oggetto dalla lista
            }
        }
    }

    #endregion


}
