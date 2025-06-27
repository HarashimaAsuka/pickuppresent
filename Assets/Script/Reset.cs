using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private static Reset instance;
    private Dictionary<string, ObjectState> objectStates = new Dictionary<string, ObjectState>();
    public string[] objectTagsToPersist; // 保持するオブジェクトのタグリスト

    private void Awake()
    {
        // シングルトンパターンの実装
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンがロードされた際にオブジェクトの状態を復元
        RestoreObjectStates();
    }

    public void SaveObjectStates()
    {
        foreach (string tag in objectTagsToPersist)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                SaveObjectState(obj);
            }
        }
    }

    private void SaveObjectState(GameObject obj)
    {
        ObjectState state = new ObjectState
        {
            Position = obj.transform.position,
            Rotation = obj.transform.rotation,
            IsActive = obj.activeSelf
        };

        objectStates[obj.name] = state;
    }

    private void RestoreObjectStates()
    {
        foreach (var kvp in objectStates)
        {
            GameObject obj = GameObject.Find(kvp.Key);
            if (obj != null)
            {
                RestoreObjectState(obj, kvp.Value);
            }
        }
    }

    private void RestoreObjectState(GameObject obj, ObjectState state)
    {
        obj.transform.position = state.Position;
        obj.transform.rotation = state.Rotation;
        obj.SetActive(state.IsActive);
    }

    [System.Serializable]
    private class ObjectState
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsActive;
    }
}
