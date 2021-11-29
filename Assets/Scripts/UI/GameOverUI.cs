using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    public void CloseGameOverUI()
    {     
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);

    }


}
