using UnityEngine;
using Src;

public class DoorScript : ObjectInfo
{
    private bool isPlayerEntered = false;

    private void Start() 
    { 
        GetComponent<SpriteRenderer>().sprite = ObjSprite; 
    }

    public void SetEnter(bool _bool)
    {
        isPlayerEntered = _bool; 
        GetComponent<BoxCollider2D>().isTrigger = isPlayerEntered; 
    }
}