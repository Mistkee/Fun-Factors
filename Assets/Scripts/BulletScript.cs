using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed, rotationSpeed;
    [SerializeField] ParticleSystem particle;
    void Start()
    {
        Invoke("DestroyBullet", 2f);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
       
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        particle.Play();
    }
}
