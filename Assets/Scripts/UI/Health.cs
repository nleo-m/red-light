using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text HealthText;

    private void Start() {
        HealthText = GetComponent<Text>();    
    }
    
    void Update()
    {
        HealthText.text = $"{PlayerState.health}%";
    }
}
