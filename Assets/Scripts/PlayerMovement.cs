using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //our local speed variable, controls player speed
    private float speed = 5f;

    //Ref. to our camera, so we always have it
    private Camera cameraReference;
    
    // Start is called before the first frame update
    void Start()
    {
        //Find our camera once, then use the ref.
        cameraReference = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from user
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Calculate and normalize our movement
        Vector3 movement = new Vector3(x, y, 0).normalized * speed * Time.deltaTime;

        //add movement to our old position
        transform.position += movement;

        //get mouse position
        Vector3 mousePos = cameraReference.ScreenToWorldPoint(Input.mousePosition);
        //fix for 3d->2d position
        mousePos.z = 0;
        //calculate direction
        mousePos -= transform.position;
        
        //aim towards mouse
        transform.up = mousePos;
        
        ScreenWarp();
    }

    private void ScreenWarp()
    {
        Vector3 position = cameraReference.WorldToScreenPoint(transform.position);
        position.x = (position.x + cameraReference.pixelWidth) % cameraReference.pixelWidth;
        position.y = (position.y + cameraReference.pixelHeight) % cameraReference.pixelHeight;
        transform.position = cameraReference.ScreenToWorldPoint(position);
    }
}
