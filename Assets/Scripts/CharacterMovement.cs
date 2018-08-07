using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
public class CharacterMovement : MonoBehaviour {
    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    private bool moveToPoint = false;
    private Vector3 endPosition;
  void Start () {
        endPosition = transform.position;
    }
  
  void FixedUpdate () {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
  }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.W)) //Up
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) //Down
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
            moveToPoint = true;
        }
    }
}
