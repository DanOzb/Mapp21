using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestThree : MonoBehaviour
{
    private bool lost = false;
    private bool won = false;
    private float tilt;
    private float moveSpeed = 40f;
    private GameObject questContainer;
    private Rigidbody2D rigid;
    [SerializeField] GameObject gameOverScreen, timer;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        questContainer = GameObject.FindGameObjectWithTag("Quest");
    }

    public void GameWon()
    {
        won = true;
        //gör något
        TransitionScript.sceneToLoad = 2;
        TransitionScript.nextTransition = true;

    }

    void Update()
    {
        tilt = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
        if(timer.GetComponent<TextMeshProUGUI>().text == "0")
        {
            GameWon();
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(tilt, -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Killzone")
        {
            questContainer.SetActive(false);
            gameOverScreen.SetActive(true);
            lost = true;
        }
    }
}
