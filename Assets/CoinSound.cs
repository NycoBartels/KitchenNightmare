using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class CoinSound : MonoBehaviour
{
    public AudioSource _audio;
    [SerializeField] private float magnitudeSoundCutoff = 1f;


    private void OnCollisionEnter(Collision collision) {
        if (collision.relativeVelocity.magnitude > magnitudeSoundCutoff) {
            //_audio.pitch = Random.Range(-10, 10) / 10;
            _audio.Play();
        }
    }
}
