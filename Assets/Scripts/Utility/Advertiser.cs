using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Responsible for advertising an available action
/// </summary>
public class Advertiser : MonoBehaviour
{
    public Need[] PromisedNeedChanges;
    public List<Consideration> Considerations;

    // Start is called before the first frame update
    void Start()
    {
        AdvertisementManager.Instance.AddAdvertiser(this);
    }

    void OnDestroy()
    {
        AdvertisementManager.Instance.RemoveAdvertiser(this);
    }

}
