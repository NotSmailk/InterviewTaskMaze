using UnityEngine;

namespace Assets.Source.Scripts.Utils
{
    public class Vector2Extra
    {
        public static Vector2 Middle(Vector2 v1, Vector2 v2)
        {
            Vector2 vector;
            var distance = Vector2.Distance(v1, v2);
            vector = Vector2.MoveTowards(v1, v2, distance / 2);
            return vector;
        }
    }
}
