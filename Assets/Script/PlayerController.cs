using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D rb2d;
    private int count;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//어떤디바이스를 쓰던 Input이 수치로 변환하여 상하로 전달.
        float moveVertical = Input.GetAxis("Vertical");//GetAxis는 방향키를 오래 누르고 있으면 쌔게 가게. (키 눌린 횟수만 받는 함수가 있다)
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);//2D의 xy축의 힘을 합성해준다.

        rb2d.AddForce(movement * speed);//그 방향으로 힘을 줘라 라는 함수
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 10){
            winText.text = "You win!";
        }
    }
}
