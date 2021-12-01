using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerControl player;
    public Text ScoreText;
    public int ScoreNum;

    public GameObject[] hearts;
    public GameOverUI gameOverUI;

    void Start()
    {
        ScoreNum = 0;
    }

    void Update()
    {
        HeartControl();
        ScoreControl();
    }

    /// <summary>
    /// 生命值图标的显示
    /// </summary>
    void HeartControl()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < player.heartNum);
        }
        if (player.heartNum == 0)
        {
            gameOverUI.ShowUI();
            Time.timeScale = 0;
        }
        //int x = player.heartNum;
        //switch (x)
        //{
        //    case 0:
        //        //canvas.GetChild(0).GetChild(0).gameObject.SetActive(false);
        //        //canvas.GetChild(0).GetChild(1).gameObject.SetActive(true);
        //        //canvas.GetChild(1).GetChild(0).gameObject.SetActive(false);
        //        //canvas.GetChild(1).GetChild(1).gameObject.SetActive(true);
        //        //canvas.GetChild(2).GetChild(0).gameObject.SetActive(false);
        //        //canvas.GetChild(2).GetChild(1).gameObject.SetActive(true);
        //        gameOverUI.ShowUI();
        //        Time.timeScale = 0;

        //        break;
        //    //case 1:
        //    //    canvas.GetChild(0).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(0).GetChild(1).gameObject.SetActive(false);
        //    //    canvas.GetChild(1).GetChild(0).gameObject.SetActive(false);
        //    //    canvas.GetChild(1).GetChild(1).gameObject.SetActive(true);
        //    //    canvas.GetChild(2).GetChild(0).gameObject.SetActive(false);
        //    //    canvas.GetChild(2).GetChild(1).gameObject.SetActive(true);
        //    //    break;
        //    //case 2:
        //    //    canvas.GetChild(0).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(0).GetChild(1).gameObject.SetActive(false);
        //    //    canvas.GetChild(1).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(1).GetChild(1).gameObject.SetActive(false);
        //    //    canvas.GetChild(2).GetChild(0).gameObject.SetActive(false);
        //    //    canvas.GetChild(2).GetChild(1).gameObject.SetActive(true);
        //    //    break;
        //    //case 3:
        //    //    canvas.GetChild(0).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(0).GetChild(1).gameObject.SetActive(false);
        //    //    canvas.GetChild(1).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(1).GetChild(1).gameObject.SetActive(false);
        //    //    canvas.GetChild(2).GetChild(0).gameObject.SetActive(true);
        //    //    canvas.GetChild(2).GetChild(1).gameObject.SetActive(false);
        //    //    break;
        //}
    }

    void ScoreControl()
    {
        ScoreNum = (int)player.transform.position.x+8;
        ScoreText.text = ScoreNum.ToString();
    }

}
