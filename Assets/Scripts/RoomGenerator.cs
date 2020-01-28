using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> listOfTiles;
    public InputField inW, inH;
    public Slider slider;
    public int[,] room;
    public int width, height, emptyfields = 50, jump;



    public void setW()
    {
        Int32.TryParse(inW.text, out width);
    }

    public void setH()
    {
        Int32.TryParse(inH.text, out height);
    }

    public void setEmpty()
    {
        emptyfields = (int) slider.value;
        jump = (100 - emptyfields) / listOfTiles.Count;
    }

    public void generate()
    {   
        
        room = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                
                    int rand = Random.Range(0, 100), whichPrefab = 0;
                    if (rand < emptyfields) whichPrefab = 0;
                    for(int k=0; k<listOfTiles.Count-1; k++)
                    {
                        if(rand > emptyfields + k*jump && rand < emptyfields + (k+1)*jump) whichPrefab = k+1;
                    }
                    room[i, j] = whichPrefab;
            }
        }
        instantiateRoom();
    }


    public void instantiateRoom()
    {
        foreach (Transform obj in GetComponentInChildren<Transform>())
        {
            if (!(obj.gameObject.tag == "Chest" || obj.gameObject.tag == "Spawner"))
            {
                Destroy(obj.gameObject);
            }
        }
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                GameObject gameObject = Instantiate(listOfTiles[room[i, j]], new Vector3(i * 7.5f, j * 7.5f), Quaternion.Euler(0, 0, 0));
                gameObject.transform.parent = transform;
            }
        }
    }

    void Start()
    {
        jump = 50 / listOfTiles.Count; 
        //generateRoom();
    }
}
