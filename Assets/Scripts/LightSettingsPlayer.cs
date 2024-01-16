using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppVolume;
    [SerializeField] PostProcessProfile Default;
    [SerializeField] PostProcessProfile NightVision;
    [SerializeField] PostProcessProfile UnderWater;
    [SerializeField] GameObject NightVisionOverlay;
    [SerializeField] GameObject Flashlight;
    [SerializeField] AudioClip FLSwitchAudio;
    [SerializeField] AudioClip NVSwitchAudio;
    AudioSource PlayerAudio;
    Light lightPower;

    bool isFlashLightOn = false;

    private void Start() {
        NightVisionOverlay.SetActive(false);
        Flashlight.SetActive(false);
        lightPower = Flashlight.GetComponent<Light>();
        PlayerAudio = Flashlight.GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        lightPower.intensity = 3f;

        if (Input.GetKeyDown(KeyCode.Z) && PlayerState.nightVisionPower > 0 || PlayerState.nightVisionPower <= 0 && PlayerState.isNightVisionOn) {
            nightVisionSwitch();
            PlayerAudio.PlayOneShot(NVSwitchAudio);
        }

        if (PlayerState.HasItem("Flashlight")) {
            if (Input.GetKeyDown(KeyCode.F) && PlayerState.flashLightPower > 0 || PlayerState.flashLightPower <= 0 && PlayerState.isFlashLightOn) {
                PlayerAudio.PlayOneShot(FLSwitchAudio);
                isFlashLightOn = !isFlashLightOn;
                flashLightSwitch();
            }
        }

        if (PlayerState.flashLightPower > 0 && PlayerState.flashLightPower < 0.1 && isFlashLightOn) {
            lightPower.intensity = 2;
            flashLightSwitch();
        }

        underWaterSwitch();
    }

    void nightVisionSwitch() {
        PlayerState.isNightVisionOn = !PlayerState.isNightVisionOn;
        ppVolume.profile = PlayerState.isNightVisionOn ? NightVision : Default;
        NightVisionOverlay.SetActive(PlayerState.isNightVisionOn);
    }

    void underWaterSwitch()
    {
        ppVolume.profile = PlayerState.isUnderWater ? UnderWater: Default;
    }

    void flashLightSwitch() {
        PlayerState.isFlashLightOn = !PlayerState.isFlashLightOn;
        Flashlight.SetActive(PlayerState.isFlashLightOn);
    }

}
