﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    private AudioManager audioManager;
    public bool isInSafeZone = false;
    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
        if (timeLeft <= 0)
        {
            audioManager.Play("derrota");
            SceneManager.LoadScene(0);
            Debug.Log("Perdeu!");
        }
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
                yield return new WaitForSeconds(1);
            if (!isInSafeZone)
            {
                timeLeft--;
            }
        }
    }
}