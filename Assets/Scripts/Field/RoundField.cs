using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundField : MonoBehaviour
{
    protected GameObject Grid_All;

    [SerializeField]
    int height ;
    [SerializeField]
    int width ;

    List<List<Imfor>> gridArray = new List<List<Imfor>>();// 2 demention list

    private void FindObject()
    {
        Grid_All = gameObject;
    }
    private void Init()
    {
        FindObject();

        for(int i = 0; i < width; i++)
            gridArray.Add(new List<Imfor>());

        int index = 0;
        for(int i=0; i < width; i++)
        {
            for(int j=0;j<height;j++)
            {
                Imfor imfor = new Imfor();
                imfor.grid = transform.GetChild(index).gameObject;
                gridArray[i].Add(imfor);
                index++;
            }
        }
    }
    void Awake()    
    {
        Init();
    }
}

class Imfor
{
    public GameObject grid; // one prefab
    public float ratio = 1.0f; // used by player scale
}

