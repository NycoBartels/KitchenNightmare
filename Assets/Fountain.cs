using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.transform.GetChild(0).TryGetComponent<Target>(out Target target)) {
            target.onTriggerEnter.Invoke();
        }
    }
}
