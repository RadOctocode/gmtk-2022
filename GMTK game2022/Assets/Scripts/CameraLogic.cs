using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // Update is called once per frame
    public GameObject player;
    void Update()
    {
        Vector3 newpos = new Vector3(player.transform.position.x, 20, player.transform.position.z);
        transform.position = newpos;

    }
}
 