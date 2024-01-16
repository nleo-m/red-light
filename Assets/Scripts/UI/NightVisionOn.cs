using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionOn : MonoBehaviour
{
    [SerializeField] GameObject OnOffIcon;

    void Update()
    {
        OnOffIcon.SetActive(PlayerState.isNightVisionOn);
    }
}