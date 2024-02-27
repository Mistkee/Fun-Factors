using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    void Start()
    {
        Invoke("SelfDestruct", 2.3f);
    }

 void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
