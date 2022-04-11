using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
