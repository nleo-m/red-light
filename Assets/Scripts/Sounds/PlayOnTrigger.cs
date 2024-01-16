using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour
{
    private AudioSource source;
    private BoxCollider col;

    private void Start() {
        col = GetComponent<BoxCollider>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Destroy(AudioManager.currentPlaying);
            source.Play();
            col.enabled = false;
            AudioManager.currentPlaying = this.gameObject;
        }
    }
}
