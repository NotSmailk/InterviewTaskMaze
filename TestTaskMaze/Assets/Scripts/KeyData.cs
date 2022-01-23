using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Src;

// ScriptableObject для ключей с записью свойтсв объекта
[CreateAssetMenu(menuName = "Keys/Default key", fileName = "New Key")]
public class KeyData : ObjData
{
    public Sprite KeySprite {
        get { return ObjSprite; }
        protected set {}
    }

    public State KeyColor {
        get { return ObjState; }
        protected set {}
    }
}
