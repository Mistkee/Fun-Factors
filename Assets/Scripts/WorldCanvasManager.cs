using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasManager : MonoBehaviour
{
    GameObject character;
    private void Awake()
    {
        character = GameObject.Find("Character");
        
    }
    void Update()
    {
        transform.forward = character.transform.forward;
    }
}
