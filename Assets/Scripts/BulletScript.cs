using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed, rotationSpeed;
    void Start()
    {
        Invoke("DestroyBullet", 2f);
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
