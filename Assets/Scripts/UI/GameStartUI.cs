using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUI : MonoBehaviour
{
    public void StartUI()
    {
        SceneManager.LoadScene(1);
    }

}
