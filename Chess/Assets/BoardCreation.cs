using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    public Transform colour1;
    public Transform colour2;
    public Transform pawn1;
    public Transform pawn2;
    public Transform castle1;
    public Transform castle2;
    public Transform knight1;
    public Transform knight2;
    public Transform bishop1;
    public Transform bishop2;
    public Transform queen1;
    public Transform queen2;
    public Transform king1;
    public Transform king2;

    private void Awake()
    {
        MakeBoard();
    }

//for each type of piece, make some pieces
    private void MakeAllPieces()
    {
        Vector3[] pawnPositions = new Vector3[8];
        for(int i = 0; i < 8; i++)
        {
            pawnPositions[i] = new Vector3();
        }
        MakePiecesOfType(pawn1, pawn2, pawnPositions);
    }

//this method makes pieces of specific type (pawn, knight, bishop etc) when fed a list of coordinates and which piece to make
    private void MakePiecesOfType(Object piece1, Object piece2, Vector3[] positions)
    {
        foreach(Vector3 pos in positions)
        {
            Instantiate(piece1, pos, Quaternion.identity);
        }
        
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i].y += 8;
            Instantiate(piece2, positions[i], Quaternion.identity);
        }
    }

    private void MakeBoard()
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
