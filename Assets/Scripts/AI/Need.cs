
using UnityEngine;

[System.Serializable]
public class Need
{
    public NeedType NeedType;
    [SerializeField] private float _value;

    public float NeedValue
    {
        get { return _value; }

        set { _value = Mathf.Clamp(value, 0f, 100f); }
    }

    public void ModifyNeedValue(float amount) => NeedValue += amount;
}

public enum NeedType
{
    Hunger,
    Joy,
    Hygiene
}