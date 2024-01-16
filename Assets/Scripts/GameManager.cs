using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject inventoryUI;
    public static string info;
    bool inventoryMenu = false;
    public bool isPaused = false;

    private void Start() {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I)) {
            isPausedSwitch();
            inventoryMenu = !inventoryMenu;
            inventoryUI.SetActive(inventoryMenu);
        }

        Time.timeScale = isPaused ? 0 : 1;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    bool isPausedSwitch() {
        return isPaused = !isPaused;
    }

    public static void setInfo(string newInfo) {
        info = newInfo;
    }
}
