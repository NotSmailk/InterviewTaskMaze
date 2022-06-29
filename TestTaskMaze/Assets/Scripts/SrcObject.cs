using UnityEngine;

namespace Src
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ObjectInfo : MonoBehaviour
    {
        [Tooltip("Основной белый спрайт")]
        public Sprite ObjSprite;

        [Tooltip("Цвет объекта")]
        public ObjectColor ObjColor;

        public void Awake() 
        { 
            ChangeColor(); 
        }

        public ObjectColor GetColor() 
        { 
            return ObjColor; 
        }

        public void ChangeColor() 
        {
            switch(ObjColor)
            {
                case ObjectColor.White: 
                    GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1); 
                    break;
                case ObjectColor.Green: 
                    GetComponent<SpriteRenderer>().material.color = new Color(0, 1, 0); 
                    break;
                case ObjectColor.Yellow: 
                    GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 0); 
                    break;
                case ObjectColor.Blue: 
                    GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 1); 
                    break;
            }            
        }

    }
    public enum ObjectColor
    {
        White,
        Yellow,
        Blue,
        Green
    }
}