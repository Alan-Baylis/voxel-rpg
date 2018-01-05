using UnityEngine;

namespace Assets.source.helpers
{
    public class GameObjectHelper 
    {
        public static Bounds CalculateBounds(RectTransform transform)
        {
            float uiScaleFactor = 1;
            Bounds bounds = new Bounds(transform.position, new Vector3(transform.rect.width, transform.rect.height, 0.0f) * uiScaleFactor);

            if (transform.childCount > 0)
            {
                foreach (RectTransform child in transform)
                {
                    Bounds childBounds = new Bounds(child.position, new Vector3(child.rect.width, child.rect.height, 0.0f) * uiScaleFactor);
                    bounds.Encapsulate(childBounds);
                }
            }

            return bounds;
        }
    }
}