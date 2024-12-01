using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;
using System.Net.NetworkInformation;


public class HackerGameScript : MonoBehaviour
{
    // Canvases
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    // Timer
    //Time timer;
    [Header("Timer")]
    public TMP_Text timerText;
    [SerializeField, Range(0, 100)] int timerLimit; //почему-то не обновляет время из движка
    float elapsedTime;
    bool freezeTime;
    [Space(10)]

    // Pins
    [Header("Pins")]
    public TMP_Text tPin001;
    public TMP_Text tPin002;
    public TMP_Text tPin003;

    [SerializeField, Range(0,10)] int pin001;
    [SerializeField, Range(0,10)] int pin002;
    [SerializeField, Range(0,10)] int pin003;

    [SerializeField, Range(-2,2)] int drillPinChange001;
    [SerializeField, Range(-2,2)] int drillPinChange002;
    [SerializeField, Range(-2,2)] int drillPinChange003;

    [SerializeField, Range(-2,2)] int hummerPinChange001;
    [SerializeField, Range(-2,2)] int hummerPinChange002;
    [SerializeField, Range(-2,2)] int hummerPinChange003;
                                
    [SerializeField, Range(-2,2)] int pickPinChange001;
    [SerializeField, Range(-2,2)] int pickPinChange002;
    [SerializeField, Range(-2,2)] int pickPinChange003;
    [Space(10)]

    // Buttons
    [Header("Buttons")]
    public Button drillBtn;
    public Button hummerBtn;
    public Button pickBtn;

    public TMP_Text drillTxt;
    public TMP_Text hummerTxt;
    public TMP_Text pickTxt;

    private string drillName = "Drill";
    private string hummerName = "Hummer";
    private string pickName = "Pick";


    void Start()
    {
        timerText.text = "0";
        freezeTime = false;
        SetRandomPinNums();
        UpdatePinButtonText(drillName);
        UpdatePinButtonText(hummerName);
        UpdatePinButtonText(pickName);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

    }

    void Update()
    {
        if (!freezeTime)
        {
            elapsedTime += Time.deltaTime;
            float currentTime = elapsedTime; // display time
            timerText.text = currentTime.ToString("#");
            if (Convert.ToInt32(currentTime) == timerLimit)
            {
                ResetTime();
                DisplayResultCanvas();
            }
        }
    }

    private void ResetTime()
    {
        elapsedTime = 0;
    }

    public void OnDrillCliked()
    {

        if (drillBtn != null)
        {
            CalculatePinSum(drillName);
        }
    }

    public void OnHummerClicked()
    {

        if (hummerBtn != null)
        {
            CalculatePinSum(hummerName);
        }
    }

    public void OnPickCliked()
    {

        if (pickBtn != null)
        {
            CalculatePinSum(pickName);
        }
    }

    private void CalculatePinSum(string toolName)
    {
        if (toolName == drillName)
        {
            pin001 += drillPinChange001;
            pin002 += drillPinChange002;
            pin003 += drillPinChange003;
        }
        else if (toolName == hummerName)
        {
            pin001 += hummerPinChange001;
            pin002 += hummerPinChange002;
            pin003 += hummerPinChange003;
        }
        else if (toolName == pickName)
        {
            pin001 += pickPinChange001;
            pin002 += pickPinChange002;
            pin003 += pickPinChange003;
        }

        UpdatePinText();
    }
    private void UpdatePinButtonText(string toolName)
    {
        if (toolName == drillName)
        {
            drillTxt.text = drillPinChange001.ToString() + "| " + 
                            drillPinChange002.ToString() + "| " + 
                            drillPinChange003.ToString() + "\n" + 
                            toolName;
        }
        else if (toolName == hummerName)
        {
           hummerTxt.text = hummerPinChange001.ToString() + "| " +
                            hummerPinChange002.ToString() + "| " +
                            hummerPinChange003.ToString() + "\n" +
                            toolName;
        }

        else if (toolName == pickName)
        {
            pickTxt.text =  pickPinChange001.ToString() + "| " +
                            pickPinChange002.ToString() + "| " +
                            pickPinChange003.ToString() + "\n" +
                            toolName;
        }
    }

    private void DisplayResultCanvas()
    {
        SetButtonActive(false);
        freezeTime = true;
        Canvas winScreen = winCanvas.GetComponent<Canvas>();
        winScreen.sortingOrder = 1;

        Canvas loseScreen = winCanvas.GetComponent<Canvas>();
        loseScreen.sortingOrder = 1;

        if (winCanvas != null && loseCanvas != null)
        {
            if (tPin001.text == tPin002.text && tPin002.text == tPin003.text)
            {
                winCanvas.SetActive(true);
            }
            else
            {
                loseCanvas.SetActive(true);
            }
        }
    }

    public void OnResetGameClicked()
    {
        elapsedTime = 0;
        freezeTime = false;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        UpdatePinButtonText(hummerName);
        UpdatePinButtonText(pickName);
        UpdatePinButtonText(drillName);
        SetRandomPinNums();
        SetButtonActive(true);
    }

    private void SetRandomPinNums()
    {
        //Random rand = new Random();
        //pin001 = rand.Next(0, 11);
        //pin002 = rand.Next(0, 11);
        //pin003 = rand.Next(0, 11);
        UpdatePinText();
    }

    private void UpdatePinText()
    {
        tPin001.text = pin001.ToString();
        tPin002.text = pin002.ToString();
        tPin003.text = pin003.ToString();
    }

    void SetButtonActive(bool enabled)
    {
        drillBtn.enabled = enabled;
        hummerBtn.enabled = enabled; 
        pickBtn.enabled = enabled;
    }
}
