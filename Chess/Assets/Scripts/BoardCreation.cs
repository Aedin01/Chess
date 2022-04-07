using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    public Vector3[] pawnPositions;
    public Vector3[] castlePositions;
    public Vector3[] knightPositions;
    public Vector3[] bishopPositions;
    public Vector3[] kingPositions;
    public Vector3[] queenPositions;
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
        MakeAllPieces();
    }

//for each type of piece, make some pieces
    private void MakeAllPieces()
    {
        pawnPositions = new Vector3[8];
        for(int i = 0; i < 8; i++)
        {
            pawnPositions[i] = new Vector3(i-4, -3, 0);
        }
        MakePiecesOfType(pawn1, pawn2, pawnPositions);

        castlePositions = new Vector3[] {new Vector3(-4, -4, 0), new Vector3(3, -4, 0)};
        MakePiecesOfType(castle1, castle2, castlePositions);

        knightPositions = new Vector3[] {new Vector3(-3, -4, 0), new Vector3(2, -4, 0)};
        MakePiecesOfType(knight1, knight2, knightPositions);

        bishopPositions = new Vector3[] {new Vector3(-2, -4, 0), new Vector3(1, -4, 0)};
        MakePiecesOfType(bishop1, bishop2, bishopPositions);

        kingPositions = new Vector3[] {new Vector3(-1, -4, 0)};
        MakePiecesOfType(king1, king2, kingPositions);

        queenPositions = new Vector3[] {new Vector3(0, -4, 0)};
        MakePiecesOfType(queen1, queen2, queenPositions);
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
            if(positions[i].y == -3)
            {
                positions[i].y += 5;
            }
            else
            {
                positions[i].y += 7;
            }
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
