using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject PrefabCube;

    // Start is called before the first frame update
    void Start()
    {
        //RandomGenerateItem(30.0f,-16.0f,36.0f,50.0f);
        //RandomGenerateItem(16.0f,30.0f,10.0f,24.0f);
        GenerateItem();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void RandomGenerateItem(float minx, float maxx, float minz, float maxz)
    {
        float firstx = RandomGeneratePosition(minx, maxx);
        float firstz = RandomGeneratePosition(minz, maxz);


        Vector3 firstpos = new Vector3(firstx, 0f, firstz);

        GameObject firstobj = Instantiate(PrefabCube, firstpos, Quaternion.identity);
        firstobj.transform.position = firstpos;
    }

    float RandomGeneratePosition(float min, float max) {
        float num = Random.Range(min, max);
        return num;
    }

    public Vector3[] poss;
    
    int RandomNumber()
    {
        int num = Random.Range(0, poss.Length);
        return num;
    }

    Vector3 GetPosition()
    {
        int num = RandomNumber();
        Vector3 firstpos = poss[num];
        return firstpos;
    }

    void GenerateItem()
    {
        Vector3 firstpos = GetPosition();
        GameObject firstobj = Instantiate(PrefabCube, firstpos, Quaternion.identity);
        firstobj.transform.position = firstpos;
    }


}
