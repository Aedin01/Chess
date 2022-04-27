using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    public Vector3[] pawnPositions;
    public Vector3[] castlePositions;
    public Vector3[] knightPositions;
    public Vector3[] bishopPositions;
    public Vector3[] kingPositions;
    public Vector3[] queenPositions;
    public static Transform[] squarePositions = new Transform[64];
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
    public Transform tile;
    [SerializeField] private Color colour1, colour2;
    public SpriteRenderer _renderer;
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
            pawnPositions[i] = new Vector3(i, 1, 0);
        }
        MakePiecesOfType(pawn1, pawn2, pawnPositions);

        castlePositions = new Vector3[] {new Vector3(0, 0, 0), new Vector3(7, 0, 0)};
        MakePiecesOfType(castle1, castle2, castlePositions);

        knightPositions = new Vector3[] {new Vector3(1, 0, 0), new Vector3(6, 0, 0)};
        MakePiecesOfType(knight1, knight2, knightPositions);

        bishopPositions = new Vector3[] {new Vector3(2, 0, 0), new Vector3(5, 0, 0)};
        MakePiecesOfType(bishop1, bishop2, bishopPositions);

        kingPositions = new Vector3[] {new Vector3(3, 0, 0)};
        MakePiecesOfType(king1, king2, kingPositions);

        queenPositions = new Vector3[] {new Vector3(4, 0, 0)};
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
            positions[i].y += 7 - 2 * positions[i].y;
            Instantiate(piece2, positions[i], Quaternion.identity);
        }
    }

    private void MakeBoard()
    {
        int i = 0;
        for(int y = 0; y < 8 ; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                var newTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                newTile.name = $"Tile {x} {y}";
                bool isModTwo = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                Debug.Log($"{isModTwo} {x} {y}");
                _renderer.color = isModTwo ? colour2 : colour1;
                squarePositions[i] = newTile;
                i++;

                if(newTile.position.x != 7)
                {
                    isModTwo = !isModTwo;
                    _renderer.color = isModTwo ? colour2 : colour1; 
                }


                // Less efficient method for above code (_renderer.color = isModTwo ? colour1 : colour2;)

                /* if(isModTwo == true)
                {
                    _renderer.color = colour1;
                }
                else
                {
                    _renderer.color = colour2;
                }  */
            }   
        }
    }
}