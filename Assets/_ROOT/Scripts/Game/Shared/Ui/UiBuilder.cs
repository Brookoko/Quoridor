namespace Quoridor.Views.Ui
{
    using System.Collections.Generic;
    using Windows;
    using UnityEngine;

    public class UiBuilder : MonoBehaviour
    {
        [SerializeField]
        private Transform windowsRoot;

        private readonly Dictionary<string, Window> cache = new();

        public T CreateWindow<T>() where T : Window
        {
            var prefab = LoadPrefab<T>();
            var window = Instantiate(prefab, windowsRoot);
            window.Show();
            return window;
        }

        private T LoadPrefab<T>() where T : Window
        {
            var path = typeof(T).Name;
            if (TryGetFromCache(path, out var prefab))
            {
                return (T)prefab;
            }
            return LoadFromResources<T>(path);
        }

        private bool TryGetFromCache(string path, out Window prefab)
        {
            return cache.TryGetValue(path, out prefab);
        }

        private T LoadFromResources<T>(string path) where T : Window
        {
            var prefab = Resources.Load<T>($"Windows/{path}");
            cache[path] = prefab;
            return prefab;
        }
    }
}
