using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject UIkey;
    private bool foundTheKey = false;
    private CountDown countDown;
    private Animator animator;
    private Rigidbody2D playerRigidbody2D;
    private float moveSpeed = 100f;
    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        countDown = GetComponent<CountDown>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal"); 
        verticalMove = Input.GetAxisRaw("Vertical");
        animator.SetFloat("horizontalMove", horizontalMove);
        animator.SetFloat("verticalMove", verticalMove);
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalMove * moveSpeed * Time.fixedDeltaTime, verticalMove * moveSpeed * Time.fixedDeltaTime);
        playerRigidbody2D.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "Fuel")
        {
            Debug.Log("Pegou Gasolina");
            Destroy(collide.gameObject);
            countDown.timeLeft += 10;
        }
        if (collide.gameObject.tag == "Key")
        {
            Debug.Log("Pegou Chave");
            Destroy(collide.gameObject);
            foundTheKey = true;
            UIkey.SetActive(true);
        }
        if (collide.gameObject.tag == "Enemy")
        {
            Debug.Log("Pegou o Player");
            Destroy(collide.gameObject);
            countDown.timeLeft -= 10;
        }
        if (collide.gameObject.tag == "Door")
        {
            if (foundTheKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Sem chave n adianta meu parsa");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "SafeZone")
        {
            Debug.Log("Ta safe");
            countDown.isInSafeZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "SafeZone")
        {
            Debug.Log("Ta safe");
            countDown.isInSafeZone = false;
        }
    }
}
