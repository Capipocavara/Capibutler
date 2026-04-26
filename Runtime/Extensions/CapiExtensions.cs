using UnityEngine;
using Random = UnityEngine.Random;

namespace Capybutler.Extensions
{
    public static class CapiExtensions
    {
        public static float RandomFromRange(this Vector2 range) => Random.Range(range.x, range.y);
        public static int RandomFromRange(this Vector2Int range) => Random.Range(range.x, range.y);
    }
}