using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static bool isUnderwater = false;
    float waterheight = 15.25f;
    UnderwaterPlayerController underwaterController;
    GroundedPlayerController groundedController;

    void CheckForWaterHeight()
    {
        isUnderwater = (transform.position.y < waterheight) ? true : false;
    }

    public void Start()
    {
        underwaterController = GetComponent<UnderwaterPlayerController>();
        groundedController = GetComponent<GroundedPlayerController>();

        if (underwaterController != null && groundedController != null)
        {
            SetController();
        }
    }

    public void Update()
    {
        CheckForWaterHeight();
        SetController();
    }

    public void SetController()
    {
        underwaterController.enabled = isUnderwater ? true : false;
        groundedController.enabled = !isUnderwater ? true : false;
    }
}
