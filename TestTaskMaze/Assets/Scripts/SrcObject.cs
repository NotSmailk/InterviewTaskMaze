using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// родительский ScriptableObject для дверей и ключей
namespace Src{
public class ObjData : ScriptableObject
{
    // задача спрайта объекту
    [Tooltip("Main sprite")]
    [SerializeField] protected Sprite ObjSprite;

    // задачу объекту цвета из enum-а
    [Tooltip("Obj Color")]
    [SerializeField] protected State ObjState;

    // enum, содержащий возможные цвета объекта
    public enum State { Yellow, Blue, Green }
}
}