using System.Collections.Generic;

namespace Extension
{
    public static class ListExtension
    {
        public static T RandomItem<T>(this List<T> list)
        {
            var index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }
    }
}