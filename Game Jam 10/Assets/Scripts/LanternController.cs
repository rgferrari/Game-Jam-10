using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LanternController : MonoBehaviour
{
    public Text countdown; //UI Text Object
    public float timeLeft = 1f * 60f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        countdown.text = ("" + timeLeft);
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
