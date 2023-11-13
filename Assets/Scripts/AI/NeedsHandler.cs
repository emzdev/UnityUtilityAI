using UnityEngine;


public class NeedsHandler : MonoBehaviour
{
    public Need[] Needs;

    public void ModifyNeedValue(NeedType needToModify, float Amount)
    {
        foreach (Need need in Needs)
        {
            if (need.NeedType == needToModify)
            {
                need.NeedValue += Amount;
                Debug.Log("Need modified " + need.NeedType + need.NeedValue);
            }
        }
    }

}

