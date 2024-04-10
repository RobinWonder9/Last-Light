using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // adjust on unity (select the sprite) to control movement speed

// Update is called once per frame
void Update()
{
  
    float horizontalInput = Input.GetAxis("Horizontal");

  
    Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

    // movevement
    transform.Translate(movement);
}
}
