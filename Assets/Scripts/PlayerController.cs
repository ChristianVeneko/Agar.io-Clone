using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class PlayerController : MonoBehaviour {

  [SerializeField] float moveSpeed = 5f;
  
  Rigidbody2D rb;
  Vector3 mousePosition, whereToMove;
  
  bool isMoving = false;
  float previousDistanceToMousePos, currentDistanceToMousePos;

  void Start() {
    rb = GetComponent<Rigidbody2D>(); 
  }

  void Update() {

    if (isMoving) 
      currentDistanceToMousePos = (mousePosition - transform.position).magnitude;

    if (Input.GetMouseButtonDown(0)) {
      previousDistanceToMousePos = 0;
      currentDistanceToMousePos = 0;
      isMoving = true;
      
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = 0f;
      
      whereToMove = (mousePosition - transform.position).normalized;
      rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
    }

    if (currentDistanceToMousePos > previousDistanceToMousePos) {
      isMoving = false;
      rb.velocity = Vector2.zero; 
    }

    if (isMoving) 
      previousDistanceToMousePos = (mousePosition - transform.position).magnitude;

  }

}