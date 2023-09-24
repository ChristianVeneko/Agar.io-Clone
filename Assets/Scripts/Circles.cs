using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circles : MonoBehaviour
{
    public float scaleX;

    void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Player")) {
      // Haz algo aquí 
      Debug.Log("UY");
      Player.instance.IncreaseSize(scaleX);
      gameObject.SetActive(false);
    }
  }
}
