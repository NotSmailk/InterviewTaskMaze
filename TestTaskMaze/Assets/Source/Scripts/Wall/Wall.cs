using UnityEngine;

namespace Assets.Source.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Wall : MonoBehaviour
    {
        public Wall Init(Sprite sprite)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            return this;
        }
    }
}