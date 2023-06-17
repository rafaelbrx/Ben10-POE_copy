using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public int maxLives = 3;
   public int currentLives;

    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

   private void Start()
   {
    currentLives = maxLives; 
   }

   public void LoseLife()
   {
    currentLives--;
    if(currentLives <= 0)
    {
        SceneManager.LoadScene("gameOver");
    }

    LifeUI lifeUI = FindObjectOfType<LifeUI>();
    if(lifeUI != null){
        lifeUI.UpdateLifeUI();
    }

   }
}