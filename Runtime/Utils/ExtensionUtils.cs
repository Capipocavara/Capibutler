using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Capibutler.Utils
{
    public static class ExtensionUtils
    {
        public static float RandomFromRange(this Vector2 range) => Random.Range(range.x, range.y);
        public static int RandomFromRange(this Vector2Int range) => Random.Range(range.x, range.y);
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);
        public static float Lerp(this float t, float a, float b) => (1f - t) * a + b * t;
        public static float InvLerp(this float v, float a, float b) => (v - a) / (b - a);
        public static float Remap(this float v, float iMin, float iMax, float oMin, float oMax) => v.InvLerp(iMin, iMax).Lerp(oMin, oMax);

        public static T RandomElementDifferentFromLast<T>(this IList<T> list, ref int lastIndex)
        {
            lastIndex = (lastIndex + Random.Range(1, list.Count - 1)) % list.Count;
            return list[lastIndex];
        }
    }
}