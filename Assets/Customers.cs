using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    private int random;

    private MeshRenderer _rend;
    [SerializeField] private Material[] mats;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private float delay;
    [SerializeField] private float faxdelay = 10f;

    private void Start() {
        _rend = GetComponent<MeshRenderer>();
    }

    public void AssignRandomSprite() {
        random = Random.Range(0, mats.Length);
        _rend.material = mats[random];

        StartCoroutine(DelayedAudio(random));
    }



    private IEnumerator DelayedAudio(int rngValue)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().clip = sounds[rngValue];
        GetComponent<AudioSource>().Play();
    }

}
