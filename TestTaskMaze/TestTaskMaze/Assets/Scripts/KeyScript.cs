using UnityEngine;
using Src;

// скрипт для ключей
public class KeyScript : ObjectInfo
{
    // задача спрайта объекта(ключа) и отключения "подсвечивания"
    private void Start() {
        GetComponent<SpriteRenderer>().sprite = ObjSprite;
    }

    // "подсвечивание" ключа
    public void OutlineActivity(bool activity){ 
        transform.GetChild(0).gameObject.SetActive(activity); 
    }
}
