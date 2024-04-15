using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowls : MonoBehaviour
{
    private Animator _anim;
    
    
    [SerializeField] private GameObject bowl;
    [SerializeField] private Transform spawnPos;

    private void Start() {
        _anim = GetComponent<Animator>();
    }

    public void SpawnBowl() {
        _anim.Play("ButtonPress");
        Instantiate(bowl, spawnPos.position, Quaternion.identity);
    }
}
