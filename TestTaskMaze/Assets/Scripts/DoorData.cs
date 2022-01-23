using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Src;

// ScriptableObject для дверей с записью свойтсв объекта
[CreateAssetMenu(menuName = "Doors/Default door", fileName = "New door")]
public class DoorData : ObjData
{
    public Sprite DoorSprite {
        get { return ObjSprite; }
        protected set {}
    }

    public State DoorColor {
        get { return ObjState; }
        protected set {}
    }
}