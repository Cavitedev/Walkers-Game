using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public float rango = 1f;
    public float speed = 20;
    float initial = 0f;

    private Rigidbody rb;

    float time = 0f;

    void Start()
    {
        initial = Time.time;
        time = initial;
        rb = GetComponent<Rigidbody>();
        AddForce();
    }

    void Update()
    {
        //update the position
        time = Time.deltaTime + time;
        float update = time - initial;
        if (update > 0.05f)
        {
            initial = Time.time;
            time = initial;
            AddForce();
        }
    }

    private void AddForce()
    {
        Vector3 movement = new Vector3(Random.Range(-rango, rango), 0, Random.Range(-rango, rango));
        rb.AddForce(movement * speed);
    }
}