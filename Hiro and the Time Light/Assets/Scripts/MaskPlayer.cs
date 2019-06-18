using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPlayer : MonoBehaviour
{
    private int timeLeft;
    private int timeTotal;
    private float equation;

    [Range(0.05f, 1f)]
    public float flickTime;

    [Range(0.005f, 0.09f)]
    public float addSize;

    float timer = 0;
    float smallTimer = 0;
    private bool bigger = true;

    public Transform target;

    void Start()
    {
        timeTotal = GameObject.Find("Player").GetComponent<CountDown>().timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        smallTimer = (float)timeTotal - (float)GameObject.Find("Player").GetComponent<CountDown>().timeLeft;

        transform.localScale = new Vector3(Mathf.Lerp(1f, .5f, smallTimer / timeTotal), Mathf.Lerp(1f, .5f, smallTimer / timeTotal), 1);

        if (timer > flickTime)
        {
            if (bigger == true)
            {
                transform.localScale = new Vector3(transform.localScale.x + addSize, transform.localScale.y + addSize, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - addSize, transform.localScale.y - addSize, transform.localScale.z);
            }

            timer = 0;
            bigger = !bigger;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, 20 * Time.deltaTime);
    }
}