/*
    
Author : Andres Mrad
Date : Tuesday 09/March/2021 @ 10:01:45 
Description : Manages the states of the game
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    #region Private Properties

    int _coinCount = 0;
    [SerializeField] int _livesCount = 3;
    int _scoreCount = 0;
    int _currentLevel = 0;
    bool _isGameOver = false;
    bool _isPaused = false;

    #endregion

    void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this.GetComponent<GameManager>();
        }
        else if (GameManager.Instance != null && GameManager.Instance != this)
        {
            Destroy(gameObject);
            return;
            // Instance = this.GetComponent<GameManager>();
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateLives(_livesCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoin()
    {
        _coinCount++;
    }

    public void UpdateLives(int lives)
    {
        _livesCount += lives;

        if (_livesCount < 0)
        {
            _isGameOver = true;
            UIManager.Instance.ShowGameOver();
        }
        else
        {
            SceneManager.LoadScene(0);
            UIManager.Instance.UpdateLives(_livesCount);
        }
    }
}
