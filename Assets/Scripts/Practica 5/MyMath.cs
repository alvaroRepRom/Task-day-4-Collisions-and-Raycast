using UnityEngine;

namespace ARR
{
    public static class MyMath
    {
        /// <returns>A random Vector3 on plane y = 0</returns>
        public static Vector3 RandomConcentricXZ(float minRadius, float maxRadius)
        {
            float radius = Random.Range(minRadius, maxRadius);
            float angle = Random.Range(0, 360f);

            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            return new(x, 0f, z);
        }
    }
}