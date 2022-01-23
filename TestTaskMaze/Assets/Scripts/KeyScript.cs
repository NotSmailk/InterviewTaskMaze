using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для ключей
public class KeyScript : MonoBehaviour
{
    // задача переменных
    [SerializeField] private KeyData keyData = null;

    // задача спрайта объекта(ключа) и отключения "подсвечивания"
    void Start() {
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = keyData.KeySprite;
    }

    // геттер данных о ключе (его свойств) 
    public KeyData GetData(){  return keyData; }

    // "подсвечивание" ключа
    public void OutlineActivity(bool activity){ transform.GetChild(0).gameObject.SetActive(activity); }
}
