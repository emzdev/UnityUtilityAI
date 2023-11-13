using UnityEngine;

/// <summary>
///     base class of a consideration when an AI scores an interactable.
///     Interactables can have multiple considerations
/// </summary>
public abstract class Consideration : ScriptableObject
{
    public virtual float EvaluateScore(AIController controller, Advertiser advertiser) { return 0f; }
}