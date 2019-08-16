using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStack : MonoBehaviour
{
    private int nAnimal;

    // Start is called before the first frame update
    void Start()
    {
        // 名前で判別する
        switch(name)
        {
            case "Frog":
                nAnimal = 0;
                break;
            case "Hiyoko":
                nAnimal = 1;
                break;
            case "Risu":
                nAnimal = 2;
                break;

            default:
                nAnimal = -1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    // ゲット関数
    public int GetAnimals()
    {
        return nAnimal;
    }
}
