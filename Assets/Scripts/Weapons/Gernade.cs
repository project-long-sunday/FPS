using Assembly_CSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gernade : MonoBehaviour
{

    [SerializeField] float delay = 3f;
    [SerializeField] float blastRadius = 5f;
    [SerializeField] float force = 700f;
    [SerializeField] LayerMask effected;
    [SerializeField] float damage = 50f;

    [SerializeField] GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay.waitFor(Explode));
    }

    // Update is called once per frame
    void Update()
    {

    }


    int Explode()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // get nerby objects
        Collider[] colidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius, effected);

        foreach (Collider nearby in colidersToDestroy)
        {
            // Damage 
            Destructible ds = nearby.GetComponent<Destructible>();
            if (ds is not null)
            {
                ds.Destroy();
            }

            Health health = nearby.GetComponent<Health>();
            if (health is not null)
            {
                health.Damage(damage);
            }
        }


        Collider[] colidersToMove = Physics.OverlapSphere(transform.position, blastRadius, effected);

        foreach (Collider nearby in colidersToMove)
        {
            // Add force 
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb is not null)
            {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }

        // Remove gernade
        Destroy(gameObject);
        return 0;
    }
}
