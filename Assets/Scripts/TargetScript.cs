using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] GameObject particules, cursor, worldUI;
    [SerializeField] int life;
    int damage;
    float height;
    Vector3 scale;
    void Start()
    {
        cursor = GameObject.Find("Cursor");
        worldUI = GameObject.Find("World Canvas");
        scale = transform.localScale;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chakram"))
        {

            damage = Random.Range(70, 120);
            life -= damage;
            
            if (life <= 0)
            {
                SoundEffects.instance.PlaySFX(SoundEffects.SoundFX.kill);
                cursor.GetComponent<Animator>().SetTrigger("Kill");
                GameManager.Instance.Killing();
                CutEnnemy();
            }
            else
            {
                SoundEffects.instance.PlaySFX(SoundEffects.SoundFX.hit);
            }
            worldUI.transform.position = transform.position + new Vector3(2, 2, 0);
            GameManager.Instance.IncreaseScore(damage, life);
            cursor.GetComponent<Animator>().SetTrigger("Attack");

            GetComponent<Rigidbody>().AddForce(transform.up*0.5f, ForceMode.Impulse);

        }
    }

    void CutEnnemy()
    {
        var cubeOne = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeOne.transform.localScale = new Vector3(scale.x, scale.y /2, scale.z);
        Rigidbody rb = cubeOne.AddComponent<Rigidbody>();
        Selfdestruct destruction = cubeOne.AddComponent<Selfdestruct>();
        cubeOne.GetComponent<Rigidbody>().AddForce(cubeOne.gameObject.transform.forward, ForceMode.Impulse);
        var cubeTwo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeTwo.transform.localScale = new Vector3(scale.x, scale.y /2,scale.z);
        Rigidbody rb2 = cubeTwo.AddComponent<Rigidbody>();
        Selfdestruct destruction2 = cubeTwo.AddComponent<Selfdestruct>();
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
