using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] GameObject particules;
    float height;
    Vector3 scale;
    void Start()
    {
        
        scale = transform.localScale;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chakram"))
        {
            height = Mathf.Abs(collision.gameObject.transform.position.y);
            Debug.Log(height);
            
            CutEnnemy();
        }
    }

    void CutEnnemy()
    {
        var cubeOne = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeOne.transform.localScale = new Vector3(scale.x, scale.y /2, scale.z);
        Rigidbody rb = cubeOne.AddComponent<Rigidbody>();
        cubeOne.GetComponent<Rigidbody>().AddForce(cubeOne.gameObject.transform.forward, ForceMode.Impulse);
        var cubeTwo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeTwo.transform.localScale = new Vector3(scale.x, scale.y /2,scale.z);
        Rigidbody rb2 = cubeTwo.AddComponent<Rigidbody>();
        cubeTwo.GetComponent<Rigidbody>().AddForce(cubeTwo.gameObject.transform.forward, ForceMode.Impulse);
        Instantiate(cubeOne, new Vector3(transform.position.x, transform.position.y + height/2, transform.position.z), transform.rotation);
        Instantiate(cubeTwo, new Vector3(transform.position.x, transform.position.y - height / 2, transform.position.z), transform.rotation);
        Instantiate(particules, new Vector3(transform.position.x, transform.position.y + height / 2, transform.position.z), transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        particules = GameObject.Find("Particle System(Clone)");
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        Destroy(particules);
        Destroy(gameObject);
    }
}
