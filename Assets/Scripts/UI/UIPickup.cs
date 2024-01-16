using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPickup : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4f;
    [SerializeField] GameObject PickupUI;

    private float RayDistance;
    private bool CanSeePickup = false;

    void Start()
    {
        PickupUI.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance ))
            CanSeePickup = hit.transform.CompareTag("Pickup");

        PickupUI.SetActive(CanSeePickup);
    }
}
