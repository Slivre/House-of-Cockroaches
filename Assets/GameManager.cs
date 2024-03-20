using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 0.2f;
        }
    }
}
