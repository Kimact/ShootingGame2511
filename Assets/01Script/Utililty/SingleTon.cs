using UnityEngine;

// 템플릿 -> 제네릭
public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Inst { get; private set; }
    private void Awake()
    {
        if(Inst == null)
        {
            Inst = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        DoAwake();
    }

    protected virtual void DoAwake() { }
}

public class SingleTonDontDestroy<T>: MonoBehaviour where T : MonoBehaviour
{
    public static T Inst { get; private set; }
    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DoAwake();
    }

    protected virtual void DoAwake() { }
}