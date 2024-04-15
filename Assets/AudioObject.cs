using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{

    private AudioSource _audio;

    private void Awake() {
        _audio = GetComponent<AudioSource>();
        StartCoroutine(DestroyDelayed());
    }

    public void PlayAudio(AudioClip clip) {
        _audio.clip = clip;
        _audio.Play();
    }
    public void PlayRandomAudio(AudioClip[] clips) {
        var random = Random.Range(0, clips.Length);
        _audio.clip = clips[random];
        _audio.Play();
    }

    private IEnumerator DestroyDelayed() {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
