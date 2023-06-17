using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        UpdateLifeUI();
    }

    // Update is called once per frame
    public void UpdateLifeUI()
    {
        int currentLives = gameManager.currentLives;

        for(int i = 0; i < heartImages.Length; i++){
            if(i < currentLives){
                heartImages[i].sprite = fullHeart;
            } else{
                heartImages[i].sprite = emptyHeart;
            }
        }
    }
}
