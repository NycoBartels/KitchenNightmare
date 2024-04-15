using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    private MeshRenderer _rend;
    [SerializeField] private Material[] mats;

    private void Start() {
        _rend = GetComponent<MeshRenderer>();
    }

    public void AssignRandomSprite() {
        _rend.material = mats[Random.Range(0, mats.Length)];
    }

}
