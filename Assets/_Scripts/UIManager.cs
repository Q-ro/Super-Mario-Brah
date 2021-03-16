/*
    
Author : Andres Mrad
Date : Thursday 11/March/2021 @ 09:39:24 
Description : Manges all UI Events
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    #region Inspector Properties

    [SerializeField] Text gameOverText;
    [SerializeField] TMPro.TMP_Text playerLivesText;

    #endregion

    void Awake()
    {
        if (UIManager.Instance == null)
        {
            UIManager.Instance = this.GetComponent<UIManager>();
        }
        else if (UIManager.Instance != null && UIManager.Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }


    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void UpdateLives(int lives)
    {
        playerLivesText.text="x "+ lives;
    }

}
