using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    public Transform colour1;
    public Transform colour2;
    public Transform colour;
    private void Awake()
    {
        for(int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if(y % 2 == 1)
                {
                    if(x % 2 == 1)
                    {
                        Instantiate(colour1, new Vector3(x-4, y-4, 0), Quaternion.identity);
                    }
                    else if(x % 2 != 1)
                    {
                     Instantiate(colour2, new Vector3(x-4, y-4, 0), Quaternion.identity);
                    }
                }
                else if(y % 2 != 1)
                {
                    if(x % 2 == 1)
                    {
                        Instantiate(colour2, new Vector3(x-4, y-4, 0), Quaternion.identity);
                    }
                    else if(x % 2 != 1)
                    {
                        Instantiate(colour1, new Vector3(x-4, y-4, 0), Quaternion.identity);
                    }
                }
            }
        }
    }
}
