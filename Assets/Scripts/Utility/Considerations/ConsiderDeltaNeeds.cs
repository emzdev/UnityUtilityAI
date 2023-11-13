using System;
using UnityEngine;

[CreateAssetMenu]
public class ConsiderDeltaNeeds : Consideration
{
    public override float EvaluateScore(AIController controller, Advertiser advertiser)
    {
        float deltaNeeds = 0f;
        Need[] currentNeeds = controller.NeedsHandler.Needs;

        foreach (Need advertisedNeedChange in advertiser.PromisedNeedChanges)
        {
            Need matchingCurrentNeed = Array.Find(currentNeeds, need => need.NeedType == advertisedNeedChange.NeedType);

            if (matchingCurrentNeed != null)
            {

                // calculate delta need
                float promisedNeedSum = matchingCurrentNeed.NeedValue + advertisedNeedChange.NeedValue;
                promisedNeedSum = Math.Clamp(promisedNeedSum, 0, 100);

                float matchingDeltaNeed = promisedNeedSum - matchingCurrentNeed.NeedValue;

                deltaNeeds += matchingDeltaNeed;
            }
        }
        return deltaNeeds;
    }
}