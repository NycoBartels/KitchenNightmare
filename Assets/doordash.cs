using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doordash : MonoBehaviour
{
    [SerializeField] private Animator doornob;
    [SerializeField] private Animator door;
    private bool enoughMoney = false;
    // Start is called before the first frame update

    private void Start() {
        MoneyCounter.MoneyGoalAchieved += UnlockDoor;
    }

    private void UnlockDoor() {
        enoughMoney = true;
    }

    public void triggeranimation()
    {
        if (enoughMoney) {
            doornob.SetTrigger("nobfall");
            door.SetTrigger("doorfall");
        }
    }
    private void OnDestroy() {
        MoneyCounter.MoneyGoalAchieved -= UnlockDoor;
    }
}
