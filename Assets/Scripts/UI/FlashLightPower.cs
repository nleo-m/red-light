using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightPower : MonoBehaviour
{
    [SerializeField] Image flashLightBar;
    [SerializeField] Image flashLightOutline;
    [SerializeField] float FLDrainTime = 75f;
    [SerializeField] float Power;

    void Update()
    {
        if (!PlayerState.HasItem("Flashlight")) {
            flashLightOutline.color = Color.gray;
            flashLightBar.gameObject.SetActive(false);
        }
        else {
            flashLightBar.gameObject.SetActive(true);
            if (PlayerState.flashLightPower < 0.1) {
                flashLightBar.color = Color.red;
            } else {
                flashLightBar.color = Color.white;
            }
        }



        if (PlayerState.isFlashLightOn) {
            flashLightBar.fillAmount -= 1f / FLDrainTime * Time.deltaTime;
            Power = flashLightBar.fillAmount;
            PlayerState.flashLightPower = Power;
        }

    }
}
