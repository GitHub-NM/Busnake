﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GC_main : MonoBehaviour
{
    [SerializeField]
    GameObject GCTextObj;
    [SerializeField]
    GameObject GCBoardObj;
    [SerializeField]
    GameObject GClightObj;
    [SerializeField]
    GameObject Score_oneObj;
    [SerializeField]
    GameObject Score_tenObj;
    [SerializeField]
    GameObject Score_hundredObj;
    [SerializeField]
    GameObject star_0Obj;
    [SerializeField]
    GameObject star_1Obj;
    [SerializeField]
    GameObject star_2Obj;

    [SerializeField]
    Vector3 GClightnextpos;
    [SerializeField]
    Vector3 GClightretrypos;
    [SerializeField]
    Vector3 GClighttitlepos;

    [SerializeField]
    Sprite[] ScoreSprites;
    [SerializeField]
    Sprite[] starSprites;

    [SerializeField]
    int Scorenum;
    [SerializeField]
    int Starnum;

    Vector3 initTextscal;
    Vector3 endTextscal;
    Vector3 initBoardpos;
    Vector3 endBoardpos;

    float timeStepText;
    float timeStepBoard;
    [SerializeField]
    float timeTextpop;
    [SerializeField]
    float timeBoardpop;
    //画面サイズ取得用
    //float Screenwidth;
    float Screenheight;
    //現在のScene取得(リトライ用)
    string nowSceneName;
    int Order;
    float scoretimer;
    float startimer;
    // enum型の定義
    public enum lightpos
    {
        next,
        retry,
        title
    };
    lightpos lightposnow;
    // Start is called before the first frame update
    void Start()
    {
        initTextscal = new Vector3(0.2f, 0.2f, 0.2f);
        endTextscal = new Vector3(1.0f, 1.0f, 1.0f);
        timeStepText = 0.0f;
        lightposnow = lightpos.next;
        //Screenwidth = Screen.width;
        Screenheight = Screen.height;
        initBoardpos = new Vector3(0, ((-Screenheight) - (GCBoardObj.GetComponent<RectTransform>().sizeDelta.x / 2)-25), 0);
        Debug.Log(GCBoardObj.GetComponent<RectTransform>().sizeDelta.x);
        endBoardpos = new Vector3(0, 0, 0);
        timeStepBoard = 0.0f;

        GCTextObj.transform.localScale = initTextscal;
        GCTextObj.SetActive(false);
        GCBoardObj.transform.localPosition = initBoardpos;
        scoretimer = 0.0f;
        startimer = 0.0f;
        star_0Obj.GetComponent<Image>().sprite = starSprites[0];
        star_1Obj.GetComponent<Image>().sprite = starSprites[0];
        star_2Obj.GetComponent<Image>().sprite = starSprites[0];
        star_0Obj.SetActive(false);
        star_1Obj.SetActive(false);
        star_2Obj.SetActive(false);
        Score_oneObj.SetActive(false);
        Score_tenObj.SetActive(false);
        Score_hundredObj.SetActive(false);
        nowSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Order)
        {

            case 0:

                if (Input.GetKey(KeyCode.Space))
                {
                    Order = 1;
                }
                break;
            case 1://Text(ゲームクリア)のpop
                GCTextObj.SetActive(true);
                GCTextObj.transform.localScale = Vector3.Lerp(initTextscal, endTextscal, timeStepText);
                timeStepText += Time.deltaTime / timeTextpop;
                if (timeStepText >= 1)
                {
                    Order = 2;
                }
                break;

            case 2://Boardのpop

                GCBoardObj.transform.localPosition = Vector3.Lerp(initBoardpos, endBoardpos, timeStepBoard);
                timeStepBoard += Time.deltaTime / timeBoardpop;
                if (timeStepBoard >= 1)
                {
                    Order = 3;
                }
                break;

            case 3://BoardのScore
                if (Scorenum <= 0)
                {
                    Scorenum = 0;
                }
                else if (Scorenum >= 999)
                {
                    Scorenum = 999;
                }
                scoretimer+= Time.deltaTime;

                Score_oneObj.SetActive(true);
                Score_oneObj.GetComponent<Image>().sprite = ScoreSprites[Scorenum % 10];
                if (scoretimer >= 1.0f)
                {
                    Score_tenObj.SetActive(true);
                    Score_tenObj.GetComponent<Image>().sprite = ScoreSprites[(Scorenum % 100) / 10];
                }
                if (scoretimer >= 2.0f)
                {
                    Score_hundredObj.SetActive(true);
                    Score_hundredObj.GetComponent<Image>().sprite = ScoreSprites[Scorenum / 100];
                    Order = 4;
                }
                    break;

            case 4://BoardのStar
                startimer += Time.deltaTime;
                
                if (Starnum >= 1)
                {
                    star_0Obj.GetComponent<Image>().sprite = starSprites[1];
                }
                if (Starnum >= 2)
                {
                    star_1Obj.GetComponent<Image>().sprite = starSprites[1];
                }
                if (Starnum >= 3)
                {
                    star_2Obj.GetComponent<Image>().sprite = starSprites[1];
                }

                if(startimer >= 1.0f)
                {
                    star_0Obj.SetActive(true);
                }
                if (startimer >= 2.0f)
                {
                    star_1Obj.SetActive(true);
                }
                if (startimer >= 3.0f)
                {
                    star_2Obj.SetActive(true);
                }

                break;
            default:
                break;
        }

        //Boardlight操作関係
        if (Order >= 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != lightpos.next)
            {
                lightposnow -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != lightpos.title)
            {
                lightposnow += 1;
            }

            if (lightposnow == lightpos.next)
            {
                GClightObj.transform.localPosition = GClightnextpos;

            }
            else if (lightposnow == lightpos.retry)
            {
                GClightObj.transform.localPosition = GClightretrypos;
                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(nowSceneName);
                }
            }
            else if (lightposnow == lightpos.title)
            {
                GClightObj.transform.localPosition = GClighttitlepos;
                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
    }
}
