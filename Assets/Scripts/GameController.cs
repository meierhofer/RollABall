using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject collectableContainer, hudContainer, GameFinishedPanel, GameOverPanel;
    public Text collectableCounter1, collectableCounter2, timeCounter;
    public bool gamePlaying { get; private set; }

    //public int countdownTime;

    private int numTotalCollectables, numCollected1, numCollected2;

    private float startTime, elapsedTime;


    private TimeSpan timePlaying;
    private bool timerGoing;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        numTotalCollectables = collectableContainer.transform.childCount;
        numCollected1 = 0;
        collectableCounter1.text = "Collectables : 0/ " + numTotalCollectables;

        //numTotalCollectables = collectableContainer2.transform.childCount;
        numCollected2 = 0;
        collectableCounter2.text = "Collectables : 0/ " + numTotalCollectables;

        timeCounter.text = "Time: 00:00.00";
        gamePlaying = true;
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void CollectItems1()
    {
        numCollected1++;
        
        string collectableCounterStr1 = "Collectables: " + numCollected1 + " / " + numTotalCollectables;
        collectableCounter1.text = collectableCounterStr1;

   

        if (numCollected1 >= (numTotalCollectables/2)+1 )
        {
            Winner.scorePlayer1 += 1;
            Winner.Level2 = "Player 1";
            EndGame();
        }

    }

    public void CollectItems2()
    {
      
        numCollected2++;

        string collectableCounterStr2 = "Collectables: " + numCollected2 + " / " + numTotalCollectables;
        collectableCounter2.text = collectableCounterStr2;

        if (numCollected2 >= (numTotalCollectables/2)+1)
        {
            Winner.scorePlayer2 += 1;
            Winner.Level2 = "Player 2";
            EndGame();
        }

    }


    private void EndGame()
    {
        gamePlaying = false;
        //Invoke("ShowGameFinishedScreen", 1.0f);
        SceneManager.LoadScene("PageLevel2");
        
    }

    private void ShowGameFinishedScreen()
    {
        GameFinishedPanel.SetActive(true);
        hudContainer.SetActive(false);
        // Creates a nicely formatted time string for the final time
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

        // Sets the final time UI component on the Game Over screen
        GameFinishedPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
        
    }

    public void ShowGameOverScreen()
    {
        GameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
        // Creates a nicely formatted time string for the final time
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        string collectedStr = "Collectables: " + numCollected1 + " / " + numTotalCollectables;

        // Sets the final time UI component on the Game Over screen
        GameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
        GameOverPanel.transform.Find("CollectablesText").GetComponent<Text>().text = collectedStr;
  
    }

    
}
