using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private GameObject _cam;
    private Transform holdingObj;
    private Transform handRoot;
    private float playerInteractDistance = 1.5f;
    private bool isActive = false;

    private void Awake() {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        handRoot = transform.GetChild(2);
    }

    private void Update() {
        if (holdingObj != null) {
            DragObject();
        }
    }

    public void StartInteraction() {
        if (holdingObj != null) {
            DropObject();
            return;
        }
        Interact();
    }
    private void DragObject() {
        holdingObj.position = handRoot.position;
    }
    private void DropObject() {
        holdingObj = null;
    }
    private void Interact() {
        RaycastHit hit;
        isActive = Physics.Raycast(_cam.transform.position, _cam.transform.TransformDirection(Vector3.forward), out hit, playerInteractDistance);

        if (isActive && hit.transform.GetComponent<CharacterJoint>() != null) {
            holdingObj = hit.transform;
        }
    }
}
