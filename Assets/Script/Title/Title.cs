using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject Startlight;
    [SerializeField]
    GameObject Endlight;
    [SerializeField]
    GameObject StartBoard;
    [SerializeField]
    GameObject EndBoard;
    int lightposnow;//0=はじめる1=終わる
    [SerializeField]
    Sprite lightonimage;
    [SerializeField]
    Sprite lightoffimage;
    [SerializeField]
    Sprite Boardonimage;
    [SerializeField]
    Sprite Boardoffimage;

    [SerializeField]
    Fade Fade;

    public bool bScenechange;//true=Scenechange中

    // Start is called before the first frame update
    void Start()
    {
        lightposnow = 0;
        Startlight.GetComponent<Image>().sprite = lightonimage;
        Endlight.GetComponent<Image>().sprite = lightoffimage;

        StartBoard.GetComponent<Image>().sprite = Boardonimage;
        EndBoard.GetComponent<Image>().sprite = Boardoffimage;
        bScenechange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //EnterKey,SpacekeyでTitle→Selectにシーン遷移
        //PCの入力モードが半角になっていないとSpaceKeyが反応しない(かなしい)
        if (lightposnow == 0 && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)))
        {
            Fade.SetFade();
            bScenechange = true;
        }
        if (Fade.m_bChage)
        {
            SceneManager.LoadScene("StageSelect");

        }

        else if (lightposnow == 1 && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif

            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != 0&& bScenechange==false)
        {
            lightposnow = 0;
            Startlight.GetComponent<Image>().sprite = lightonimage;
            Endlight.GetComponent<Image>().sprite = lightoffimage;

            StartBoard.GetComponent<Image>().sprite = Boardonimage;
            EndBoard.GetComponent<Image>().sprite = Boardoffimage;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != 1 && bScenechange == false)
        {
            lightposnow = 1;
            Startlight.GetComponent<Image>().sprite = lightoffimage;
            Endlight.GetComponent<Image>().sprite = lightonimage;

            StartBoard.GetComponent<Image>().sprite = Boardoffimage;
            EndBoard.GetComponent<Image>().sprite = Boardonimage;
        }
    }
}
