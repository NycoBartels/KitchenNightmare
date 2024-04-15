using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{

    public static event Action MoneyAdd;
    public static event Action MoneyGoalAchieved;
    private TextMeshProUGUI label;

    [SerializeField] private int maxMoney;
    private int currentMoney;

    private float startingFontSize, bigFontSize;
    private float elapsedTime;

    private void Start() {
        label = GetComponent<TextMeshProUGUI>();
        startingFontSize = label.fontSize;
        bigFontSize = label.fontSize * 1.3f;
        MoneyAdd += GetOneMoney;
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        label.fontSize = Mathf.Lerp(bigFontSize, startingFontSize, elapsedTime * 2);
    }

    public static void MoneyAdded() {
        MoneyAdd?.Invoke();
    }
    public static void FinishMoneyGoal() {
        MoneyGoalAchieved?.Invoke();
    }
    private void GetOneMoney() {
        elapsedTime = 0f;
        currentMoney++;
        label.text = currentMoney.ToString() + " / " + maxMoney.ToString() + "g";
        if (currentMoney > maxMoney) {
            FinishMoneyGoal();
        }
    }

    private void OnDestroy() {
        MoneyAdd -= GetOneMoney;
    }


}
