using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionPower : MonoBehaviour
{
    [SerializeField] Image nightVisionBar;
    [SerializeField] float NVDrainTime = 30f;
    [SerializeField] float Power;

    void Update()
    {
        if (PlayerState.isNightVisionOn) {
            nightVisionBar.fillAmount -= 1f / NVDrainTime * Time.deltaTime;
            Power = nightVisionBar.fillAmount;
            PlayerState.nightVisionPower = Power;
        }

        if (PlayerState.nightVisionPower < 0.2) {
            nightVisionBar.color = Color.red;
        } else {
            nightVisionBar.color = Color.white;
        }
    }
}
