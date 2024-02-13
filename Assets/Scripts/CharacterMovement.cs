using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed, camSensitivity;
    [SerializeField] Camera cam;
    [SerializeField] GameObject bullet;
    Vector3 input;
    Rigidbody rb;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Camera Movement
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(0, -rotateHorizontal * camSensitivity, 0);
        Vector3 camY = new Vector3(rotateVertical * camSensitivity,0, 0);
        transform.eulerAngles -= rotation;
        cam.transform.eulerAngles -= camY;
       
        //Player Movement
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Player Shooting
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z) + (cam.transform.forward*1.5f), cam.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        if (input.y > 0.1)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
