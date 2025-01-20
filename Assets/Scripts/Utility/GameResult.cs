using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] enemies;
    [SerializeField] private Transform win;

    [SerializeField] private Text resultText;
    [SerializeField] private float resultDistanceToEnemy = 1.0f;
    [SerializeField] private float resultDistanceToWin = 1.5f;
    


    
    void Start()
    {
        if (resultText != null)
        {
            resultText.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {
        WinCheck();
        isPlayerLose(enemies);
    }
    void WinCheck()
    {
        float distancePlayerToWin = Vector3.Distance(player.position, win.position);
        Debug.Log(distancePlayerToWin);
        if (distancePlayerToWin <= resultDistanceToWin)
            if (resultText != null)
            {
                resultText.text = "You Win!";
                Debug.Log("Player Win");
                Time.timeScale = 0.0f;
            }

    }

    void isPlayerLose(Transform[] enemies)
    {
        if(enemies.Length < 0)
            return;
        for(int i = 0;i < enemies.Length; i++)
        {
            float distancePlayerToEnemy = Vector3.Distance(player.position, enemies[i].position);

            if (distancePlayerToEnemy <= resultDistanceToEnemy)
            {
                Debug.Log("Player Lose");
                if (resultText != null)
                {
                    resultText.text = "You Lose!";
                    Time.timeScale = 0.0f;
                }
                    

            }
        }
    }
} 
        
