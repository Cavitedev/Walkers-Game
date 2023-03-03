using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour {

    public float speed;
    public TMP_Text countText;
    public TMP_Text hpText;
    public TMP_Text finalText;
    public int goal;

    private Rigidbody rb;
    private int count;
    private int hp;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        hp = 3;
        SetCountText ();
        //winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Profit Object"))
        {
            other.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 0.5f, Random.Range(-9.0f, 9.0f));
            count = count + 1;
            SetCountText ();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Minion Enemigo"))
        {
            hp = hp - 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Puntos Equipo Azul: " + count.ToString ();
        hpText.text = "Vidas Equipo Azul: " + hp.ToString ();
        if (hp <= 0)
        {
            Time.timeScale = 0f;
            finalText.text = "You died";
        }
        if (count >= goal)
        {
            Time.timeScale = 0f;
            finalText.text = "You got all the coins!";
        }



    }
}