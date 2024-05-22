using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestThree : MonoBehaviour
{
    public bool isFlat = true;
    public bool lost = false;
    public bool won = false;
    private float tilt;
    private float moveSpeed = 40f;
    private GameObject questContainer;
    private Rigidbody2D rigid;
    [SerializeField] GameObject gameOverScreen;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("GameWon", 10);
        questContainer = GameObject.FindGameObjectWithTag("Quest");
    }

    //ta bort innan muntan
    public void Next()
    {
        SceneManager.LoadScene(2);
    }

    //ta bort innan muntan
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void GameWon()
    {
        if (!lost)
        {
            won = true;
            questContainer.SetActive(false);
            //gör något
            SceneManager.LoadScene(2);
        }

    }

    void Update()
    {
        tilt = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(tilt, -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Killzone")
        {
            if (!won)
            {
                questContainer.SetActive(false);
                gameOverScreen.SetActive(true);
                lost = true;
            }
        }
    }
}
