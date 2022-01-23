using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для дверей
public class DoorScript : MonoBehaviour
{
    // задача переменных
    [SerializeField] private DoorData doorData = null;
    protected bool enterPlayer = false;

    // задача спрайта объекта(двери)
    void Start() { GetComponent<SpriteRenderer>().sprite = doorData.DoorSprite; }

    // если игрок вошел в дверь с нужным цветом, то она становится "прозрачной" (триггером)
    private void Update() { GetComponent<BoxCollider2D>().isTrigger = enterPlayer; }

    // задача переменной, отвечающей за возможность пройти через эту дверь
    public void SetEnter(bool _bool){ enterPlayer = _bool; }

    // геттер данных о двери (его свойств)
    public DoorData GetData(){ return doorData; }
}
