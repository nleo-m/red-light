using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightOn : MonoBehaviour
{
    [SerializeField] GameObject OnOffIcon;

    void Update()
    {
        OnOffIcon.SetActive(PlayerState.isFlashLightOn);
    }
}
