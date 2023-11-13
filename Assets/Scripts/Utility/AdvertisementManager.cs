using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Keeps track of all advertisements for AI agents to access.
/// </summary>
public class AdvertisementManager : MonoBehaviour
{
    public static AdvertisementManager Instance { get; private set; }

    public List<Advertiser> Advertisers { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Advertisers = new List<Advertiser>();
        }
    }

    public void AddAdvertiser(Advertiser advertiserToAdd)
    {
        if (!Advertisers.Contains(advertiserToAdd))
        {
            Advertisers.Add(advertiserToAdd);
        }
    }

    public void RemoveAdvertiser(Advertiser advertiserToRemove)
    {
        if (Advertisers.Contains(advertiserToRemove))
        {
            Advertisers.Remove(advertiserToRemove);
        }
    }

    private void DebugAllAdvertisers()
    {
        Debug.Log(string.Join(", ", Advertisers));
    }
}
