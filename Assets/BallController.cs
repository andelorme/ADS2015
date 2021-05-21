using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Vector3 lastVelocity;
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.lastVelocity = this.rb.velocity;
    }

    private void OnCollisionEnter2D( Collision2D coll ) {
        var speed = this.lastVelocity.magnitude;
        var direction = Vector3.Reflect(this.lastVelocity.normalized, coll.contacts[0].normal);
        if(coll.collider.gameObject.layer == 3)  this.rb.velocity = direction * Mathf.Max(speed,5.0f);
    }
}
