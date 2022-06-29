using UnityEngine;
using Src;

public class KeyScript : ObjectInfo
{
    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = ObjSprite;
    }

    public void OutlineActivity(bool activity)
    { 
        transform.GetChild(0).gameObject.SetActive(activity); 
    }
}