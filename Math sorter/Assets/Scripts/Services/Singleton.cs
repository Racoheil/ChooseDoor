using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        var instances = FindObjectsOfType<T>();
        if (instances.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (Instance == null)
        {
            Instance = this as T;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
}
