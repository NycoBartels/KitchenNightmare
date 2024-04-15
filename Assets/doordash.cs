using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doordash : MonoBehaviour
{
    [SerializeField] private Animator doornob;
    [SerializeField] private Animator door;
    private AudioSource _audio;
    [SerializeField] private bool enoughMoney = false;
    // Start is called before the first frame update

    private void Start() {
        _audio = GetComponent<AudioSource>();
        MoneyCounter.MoneyGoalAchieved += UnlockDoor;
    }

    private void UnlockDoor() {
        enoughMoney = true;
    }

    public void triggeranimation()
    {
        if (enoughMoney) {
            _audio.Play();
            doornob.SetTrigger("nobfall");
            door.SetTrigger("doorfall");
        }
    }
    private void OnDestroy() {
        MoneyCounter.MoneyGoalAchieved -= UnlockDoor;
    }
}
