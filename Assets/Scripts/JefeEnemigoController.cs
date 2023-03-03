using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class JefeEnemigoController : MonoBehaviour {

    public float rango = 1f;
    public float speed = 20;

    private Rigidbody rb;

    float time = 0f;
    float initial = 0f;

    public TMP_Text countText;
    public TMP_Text hpText;
    public TMP_Text finalText;
    public int goal;

    private int count;
    private int hp;
    
    void Start()
    {
        initial = Time.time;
        time = initial;
        count = 0;
        hp = 3;
        finalText.text="";
        GetComponent<Rigidbody>().AddForce(Random.Range(-rango,rango),0,Random.Range(-rango,rango));
        SetCountText ();
        //transform.position = new Vector3(0f,0.5f,2f);
    }

    void Update()
    {
        //update the position
        time = Time.deltaTime + time;
        float update = time - initial;
        if (update > 0.05f){
            initial = Time.time;
            time = initial;
            Vector3 movement = new Vector3 (Random.Range(-rango,rango),0,Random.Range(-rango,rango));
            GetComponent<Rigidbody>().AddForce(movement * speed);
        }
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
        if (other.gameObject.CompareTag ("Minion Aliado"))
        {
            hp = hp - 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Red Team Points: " + count.ToString ();
        hpText.text = "Red Team Lifes: " + hp.ToString ();
        if (hp <= 0)
        {
            Time.timeScale = 0f;
            finalText.text = "Enemy died";
        }
        if (count >= goal)
        {
            Time.timeScale = 0f;
            finalText.text = "Enemy got all the coins";
        }


    }
}