using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction { get; set; }
    public float speed { get; set; }

    public float damage { get; set; } = 20;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Bullet hit ");
        var health = other.gameObject.GetComponent<Health>();
        if (health is not null)
        {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }



}
