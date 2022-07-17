using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPointManager : MonoBehaviour
{
    public TMP_Text actionPointText;
    int actionPoints = 0;
    string prefix = "Actions: ";

    // Start is called before the first frame update
    void Start() {
        actionPointText.text = prefix + "-";
    }

    public void SetActionPoints(int points) {
        actionPoints = points;
        actionPointText.text = prefix + actionPoints.ToString();
    }

    public void DeductActionPoint() {
        actionPoints = actionPoints - 1;
        actionPointText.text = prefix + actionPoints.ToString();
    }
}
