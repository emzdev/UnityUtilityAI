using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject TargetObject;
    public NavMeshAgent NavAgent;
    public NeedsHandler NeedsHandler;

    private State _currentState;

    void Awake()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        NeedsHandler = GetComponent<NeedsHandler>();
    }

    void Start()
    {
        SetState(new WaitState(this));
    }

    void Update()
    {
        _currentState?.UpdateState();
    }

    public void SetState(State newState)
    {
        _currentState?.OnStateExit();

        _currentState = newState;

        _currentState?.OnStateEnter();
    }

    public void MoveToDestination(Vector3 destinationVector)
    {
        NavAgent.SetDestination(destinationVector);
    }

    public void DestroyCurrentTarget()
    {
        Destroy(TargetObject);
        TargetObject = null;
    }

    /// <summary>
    ///     TargetObject selection
    /// </summary>
    /// <returns>true if successful</returns>
    public bool SelectNewTarget()
    {
        {
            var allAdvertisers = AdvertisementManager.Instance.Advertisers;

            if (allAdvertisers.Count > 0)
            {
                var advertiserScores = ScoreAdvertisers(allAdvertisers);

                // Sorting the dictionary based on the scores in descending order
                var sortedAdvertisersScores = advertiserScores.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                var winningAdvertiser = sortedAdvertisersScores.First();

                TargetObject = winningAdvertiser.Key.gameObject;

                foreach (var ad in sortedAdvertisersScores)
                {
                    Debug.Log(ad.Key.name + ad.Value);
                }

                return true;
            }

            Debug.Log("Failed to find new target");
            return false;

        }
    }

    private Dictionary<Advertiser, float> ScoreAdvertisers(List<Advertiser> advertisersToScore)
    {
        // Creating a dictionary with Advertiser as the key and the sum of Considerations' scores as the value
        Dictionary<Advertiser, float> advertiserScores = advertisersToScore.ToDictionary(
        advertiser => advertiser,
        advertiser => advertiser.Considerations.Sum(consideration => consideration.EvaluateScore(this, advertiser))
        );

        return advertiserScores;
    }

}
