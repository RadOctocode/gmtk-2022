using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    public float Range;
    int _interactiveLayer;
    ActionPointHandler _actionPoints;
    ScoreManager scoreHUD;
    ActionPointManager rollHUD;

    void Start()
    {
        _interactiveLayer = 1 << 6;
        _actionPoints = GetComponent<ActionPointHandler>();
        scoreHUD = Object.FindObjectOfType<ScoreManager>();
        rollHUD = Object.FindObjectOfType<ActionPointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTreasure();
    }

    void CheckForTreasure()
    {
        var collidersInSight = Physics.OverlapSphere(transform.position, Range, _interactiveLayer);
        foreach (var collider in collidersInSight)
        {
            var currentObject = collider.GetComponent<Interactable>();
            if (currentObject) {
                Debug.Log($"Found a piece: {currentObject.name}");
                scoreHUD.IncrementScore();
                currentObject.Collect();
                Destroy(currentObject.gameObject);
                _actionPoints.DeductActionPoint();
                rollHUD.DeductActionPoint();
            }
        }
    }
}
