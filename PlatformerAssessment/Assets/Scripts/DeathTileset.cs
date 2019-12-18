using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTileset : MonoBehaviour
{

    void OnTriggerEnter2D()
        {
        if (GameObject.FindGameObjectsWithTag("DeathTileset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
        }
}
