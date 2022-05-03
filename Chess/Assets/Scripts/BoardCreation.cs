using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    public static Transform[] squarePositions = new Transform[64];
    public static Transform[] piecePositions = new Transform[64];
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
        MakePiecesOfType(pawn1, pawn2, 0, 8, true);

        MakePiecesOfType(castle1, castle2, 0, 2);

        MakePiecesOfType(knight1, knight2, 1, 2);

        MakePiecesOfType(bishop1, bishop2, 2, 2);

        MakePiecesOfType(king1, king2, 3, 1);

        MakePiecesOfType(queen1, queen2, 4, 1);
    }

//this method makes pieces of specific type (pawn, knight, bishop etc) when fed a list of coordinates and which piece to make
    private void MakePiecesOfType(Object piece1, Object piece2, byte piece, byte instances, bool row = false)
    {
        for (int i = 0; i < instances; i++)
        {
            int x = row ? i : 7 * i + (-2 * i + 1) * piece;
            int y = row ? 1 : 0;
            Instantiate(piece1, new Vector3(x, y), Quaternion.identity);
            Instantiate(piece2, new Vector3(x, 7 - y), Quaternion.identity);
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