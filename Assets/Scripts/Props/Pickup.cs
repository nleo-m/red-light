using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] string itemName;
    bool PlayerInRange = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && PlayerInRange) {
            PlayerState.AddItem($"{itemName}");
            GameManager.setInfo($"You've picked up {itemName}");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerInRange = false;
        }
    }
}
