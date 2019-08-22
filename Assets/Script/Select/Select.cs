using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject light_Stage0;
    [SerializeField]
    GameObject light_Stage1;
    [SerializeField]
    GameObject light_Stage2;
    [SerializeField]
    GameObject light_Stage3;
    [SerializeField]
    GameObject light_Title;
    [SerializeField]
    GameObject Board_Stage0;
    [SerializeField]
    GameObject Board_Stage1;
    [SerializeField]
    GameObject Board_Stage2;
    [SerializeField]
    GameObject Board_Stage3;
    [SerializeField]
    GameObject Board_Title;
    [SerializeField]
    Sprite lightonimage;
    [SerializeField]
    Sprite lightoffimage;
    [SerializeField]
    Sprite Boardonimage;
    [SerializeField]
    Sprite Boardoffimage;
    public int lightposnow;//0~3→stage1~4 4=タイトルに戻る

    // Start is called before the first frame update
    void Start()
    {
        lightposnow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouseclick,EnterKey,SpacekeyでStageSelect→Gamemainにシーン遷移
        //PCの入力モードが半角になっていないとSpaceKeyが反応しない
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Gamemain");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != 0)
        {
            lightposnow -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != 4)
        {
            lightposnow += 1;
        }
        switch (lightposnow)
        {
            case 0:
                light_Stage0.GetComponent<Image>().sprite = lightonimage;
                light_Stage1.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage0.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage1.GetComponent<Image>().sprite = Boardoffimage;
                break;
            case 1:
                light_Stage1.GetComponent<Image>().sprite = lightonimage;
                light_Stage0.GetComponent<Image>().sprite = lightoffimage;
                light_Stage2.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage1.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage0.GetComponent<Image>().sprite = Boardoffimage;
                Board_Stage2.GetComponent<Image>().sprite = Boardoffimage;
                break;
            case 2:
                light_Stage2.GetComponent<Image>().sprite = lightonimage;
                light_Stage1.GetComponent<Image>().sprite = lightoffimage;
                light_Stage3.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage2.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage1.GetComponent<Image>().sprite = Boardoffimage;
                Board_Stage3.GetComponent<Image>().sprite = Boardoffimage;
                break;
            case 3:
                light_Stage3.GetComponent<Image>().sprite = lightonimage;
                light_Stage2.GetComponent<Image>().sprite = lightoffimage;
                light_Title.GetComponent<Image>().sprite = lightoffimage;
                
                Board_Stage3.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage2.GetComponent<Image>().sprite = Boardoffimage;
                Board_Title.GetComponent<Image>().sprite = Boardoffimage;
                break;
            case 4:
                light_Title.GetComponent<Image>().sprite = lightonimage;
                light_Stage3.GetComponent<Image>().sprite = lightoffimage;

                Board_Title.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage3.GetComponent<Image>().sprite = Boardoffimage;
                break;
        }
    }
}
