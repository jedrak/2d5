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
                    else if (rand > emptyfields && rand < emptyfields + jump) whichPrefab = 1;
                    else if (rand > emptyfields + jump && rand < emptyfields + 2*jump) whichPrefab = 2;
                    else if (rand > emptyfields + 2*jump && rand < emptyfields + 3*jump) whichPrefab = 3;
                    else if (rand > emptyfields + 3*jump && rand < emptyfields + 4*jump) whichPrefab = 4;
                    else if (rand > emptyfields + 4*jump && rand < emptyfields + 5*jump) whichPrefab = 5;
                    else if (rand > emptyfields + 5*jump && rand < emptyfields + 6*jump) whichPrefab = 6;
                    else if (rand > emptyfields + 6*jump && rand < emptyfields + 7*jump) whichPrefab = 7;
                    else if (rand > emptyfields + 7*jump && rand < emptyfields + 8*jump) whichPrefab = 8;
                    else if (rand > emptyfields + 8*jump && rand < emptyfields + 9*jump) whichPrefab = 9;
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
