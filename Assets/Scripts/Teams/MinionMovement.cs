using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class MinionMovement : MonoBehaviour {

    [FormerlySerializedAs("rango")] public float range = 1f;

    public float speed = 20;

    private Rigidbody rb;

    float time = 0f;
    float initial = 0f;
    void Start()
    {
        initial = Time.time;
        time = initial;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-range,range),0,Random.Range(-range,range));
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
            Vector3 movement = new Vector3 (Random.Range(-range,range),0,Random.Range(-range,range));
            rb.AddForce(movement * speed);
        }
    }
}