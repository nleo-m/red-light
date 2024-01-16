using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public static int health = 100;
    public static bool isFlashLightOn = false, isNightVisionOn = false, isUnderWater = false;
    public static float flashLightPower = 1, nightVisionPower = 1;
    public static List<string> items = new List<string>();

    public static bool HasItem(string itemName) {
        return items.Contains(itemName);
    }

    public static void AddItem(string itemName) {
        items.Add(itemName);
        Debug.Log(items);
    }

}
