using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    public float Range;
    int _interactiveLayer;
    ActionPointHandler _actionPoints;

    void Start()
    {
        _interactiveLayer = 1 << 6;
        _actionPoints = GetComponent<ActionPointHandler>();
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
                currentObject.Collect();
                Destroy(currentObject.gameObject);
                _actionPoints.DeductActionPoint();
            }
        }
    }
}
