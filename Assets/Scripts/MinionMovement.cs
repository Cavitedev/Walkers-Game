using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {

    public float rango = 1f;

    public float speed = 20;

    private Rigidbody rb;

    float time = 0f;
    float initial = 0f;
    void Start()
    {
        initial = Time.time;
        time = initial;
        GetComponent<Rigidbody>().AddForce(Random.Range(-rango,rango),0,Random.Range(-rango,rango));
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
}