using UnityEngine;

namespace Assets.Source.Scripts.Utils
{
    public static class RendererExtra
    {
        public static void SetColor(Renderer renderer, string colorTag, Color color)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(colorTag, color);
            renderer.SetPropertyBlock(propertyBlock);
        }
    }
}
