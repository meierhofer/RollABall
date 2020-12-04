using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject collectableContainer, hudContainer, GameFinishedPanel, GameOverPanel;
    public Text collectableCounter, timeCounter;
    public bool gamePlaying { get; private set; }

    //public int countdownTime;

    private int numTotalCollectables, numCollected;

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
        numCollected = 0;
        collectableCounter.text = "Collectables : 0/ " + numTotalCollectables;
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

    public void CollectItems()
    {
        numCollected++;

        string collectableCounterStr = "Collectables: " + numCollected + " / " + numTotalCollectables;
        collectableCounter.text = collectableCounterStr;

        if(numCollected >= numTotalCollectables)
        {
            EndGame();
        }

    }

    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameFinishedScreen", 1.0f);
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
        string collectedStr = "Collectables: " + numCollected + " / " + numTotalCollectables;

        // Sets the final time UI component on the Game Over screen
        GameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
        GameOverPanel.transform.Find("CollectablesText").GetComponent<Text>().text = collectedStr;
    }
}
