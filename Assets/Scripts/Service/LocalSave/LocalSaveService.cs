using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio.AshEdge.Service.LocalSave
{
    public class LocalSaveService
    {
        public void SaveData<T>(T data)
        {
            var saveKey = data.GetType().Name;
            var jsonData = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(saveKey, jsonData);
            PlayerPrefs.Save();
        }
        public T LoadData<T>() where T : new()
        {
            var loadKey = typeof(T).Name;
            if (PlayerPrefs.HasKey(loadKey))
            {

                var jsonData = PlayerPrefs.GetString(loadKey, string.Empty);
                return JsonUtility.FromJson<T>(jsonData);
            }
            return new T();
        }
    }
}
