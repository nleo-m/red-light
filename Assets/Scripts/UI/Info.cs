using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Info : MonoBehaviour
{
    Text info;
    private void Start() {
        info = GetComponent<Text>();
    }
    void Update()
    {
        info.text = $"{GameManager.info}";
    }
}
