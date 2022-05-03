using UnityEngine;
using System;

public class MoveController : MonoBehaviour
{
    private bool isHeld = false;
    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PositionCheck(this.gameObject);
        }
    }
    void PositionCheck(GameObject piece)
    {
        byte x = Convert.ToByte(this.gameObject.transform.position.x);
        byte y = Convert.ToByte(this.gameObject.transform.position.y);
        switch(this.gameObject.tag)
        {
            case "Pawn":
                PawnAlgorithm(x, y);
                break;
        }
    }
    void PawnAlgorithm(byte x, byte y)
    {

    }
    
}
