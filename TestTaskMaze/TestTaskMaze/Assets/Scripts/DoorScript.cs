using UnityEngine;
using Src;

// скрипт для дверей
public class DoorScript : ObjectInfo
{
    // задача полей
    private bool isPlayerEntered = false;

    // задача спрайта объекта(двери)
    private void Start() { 
        GetComponent<SpriteRenderer>().sprite = ObjSprite; 
    }

    // задача переменной, отвечающей за возможность пройти через эту дверь
    public void SetEnter(bool _bool){
        isPlayerEntered = _bool; 
        GetComponent<BoxCollider2D>().isTrigger = isPlayerEntered; 
    }
}