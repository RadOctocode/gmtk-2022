using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Camera mainCamera;

    void Start() {
        mainCamera = Object.FindObjectOfType<Camera>();

    }

    public void RestartButton(){
        //Debug.Log("Reloading " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("PrototypeCasino");


    }
    public void Setup(){
        gameObject.SetActive(true);
    }

    public void Unset() {
        gameObject.SetActive(false);
    }


}
