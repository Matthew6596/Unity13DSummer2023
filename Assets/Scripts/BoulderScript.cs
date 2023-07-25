using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody rb;
    [Tooltip("Adjusts the thrust of the boulder")]
    [Range(-100,500)]
    public float thrust = 100;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            ResetBoulder();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.LogError("Boulder hit player correctly, no error here lol");
            ResetBoulder();
        }
    }

    void ResetBoulder()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
    }
}
