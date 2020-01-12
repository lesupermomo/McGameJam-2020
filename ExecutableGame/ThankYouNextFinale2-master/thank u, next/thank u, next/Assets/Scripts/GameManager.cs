﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemies;
    public GameObject winMenu;
    #region Variables

    /// <summary>
    /// Gloabl timer to keep track of time
    /// </summary>
    public float g_timer;
    /// <summary>
    /// Timer before door is unlocked
    /// </summary>
    public float g_lockTimer = 61f;

    /// <summary>
    /// Boolean used to determined if player filled victory conditions
    /// </summary>
    [SerializeField]
    public bool g_gameEnd = false;

    /// <summary>
    /// Boolean used to check if player is dead
    /// </summary>
    [SerializeField]
    public bool g_playerDead = false;

    // Rocket mechanics 
    private int RocketParts = 3;
    public int invRocket;

    public GameObject cantgobackMessage;

    public bool door_unlocked;

    public float gameOverTimer = 0f; 
    
    #endregion

    #region Base Methods
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        
        invRocket = 0;
        // cantgobackMessage.SetActive(false);
        winMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        /*if (g_playerDead == true)
        {
            player.GetComponent<CharacterAnimator>().isDead = true;//the animator controller will be triggered
            Debug.Log("do you se ann animation");
            GameOver();

        }*/

        if (g_gameEnd == true)
        {
            Victory();
        }
        if (g_playerDead) {
            gameOverTimer += Time.deltaTime;
        }

        if (gameOverTimer > 3.5f) {
            gameOverTimer = 0f;
            SceneManager.LoadScene(0);
        }

    }

    



    private void FixedUpdate()
    {
        g_timer += Time.deltaTime;
        g_lockTimer -= Time.deltaTime;
        
        if (g_lockTimer <= 0)
        {
            Debug.Log("Door is open");
        }
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// Trigger game over events
    /// </summary>
    public void GameOver()
    {
        Debug.Log("Game Over");
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            enemies.transform.GetChild(i).gameObject.GetComponent<EnnemyAI>().Unattack();
        }
       
    }

    /// <summary>
    /// Trigger victory events
    /// </summary>
    public void Victory()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine("VictoryCooldown");
    }

    public void kill()
    {
        player.GetComponent<CharacterAnimator>().isDead = true;//the animator controller will be triggered
        GameOver();

        g_playerDead = true;
    }

    IEnumerator VictoryCooldown()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

    }

    #endregion


}
