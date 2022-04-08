using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCanAttackScript : MonoBehaviour
{
    public Transform[] squarePositions = new Transform[64];
    public Transform lockedSquare;
    private void Awake()
    {
        for(int i = 0; i < 64; i++)
        {
            squarePositions[i] = BoardCreation.squarePositions[i];
        }
        CheckSquare();
    }
    private void CheckSquare()
    {
        foreach(Transform pos in squarePositions)
        {
            if(transform.position == pos.position)
            {
                lockedSquare = pos;
                Debug.Log(lockedSquare.position);
            }
        }
    }
}
