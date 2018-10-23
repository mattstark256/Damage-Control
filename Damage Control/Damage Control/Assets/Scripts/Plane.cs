using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [HideInInspector]
    public PlaneSO planeSO;
    [HideInInspector]
    public WaitSlot waitSlot;
    [HideInInspector]
    public Country country;

    const float arriveDistance = 1000;

    public int RemainingWaits
    {
        get;
        set;
    }

    public bool isSelected;


    private void Start()
    {
        RemainingWaits = planeSO.maxWaits;
    }


    public void Arrive(float duration)
    {
        StartCoroutine(ArriveCoroutine(duration));
    }


    private IEnumerator ArriveCoroutine(float duration)
    {
        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localPosition = (Vector3.right * (f - 1)) * arriveDistance;

            yield return null;
        }
    }

    public void Land(float duration, Airport airport)
    {
        StartCoroutine(LandCoroutine(duration, airport));
    }

    private IEnumerator LandCoroutine(float duration, Airport airport)
    {
        transform.parent = null;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = airport.transform.position;
        Vector3 startScale = transform.localScale;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg* Mathf.Atan((endPosition.y - startPosition.y) / (endPosition.x - startPosition.x)));

        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localPosition = Vector3.Lerp(startPosition, endPosition, f);
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, f);

            yield return null;
        }
        Destroy(gameObject);
    }


    public void Leave(float duration)
    {
        StartCoroutine(LeaveCoroutine(duration));
    }

    private IEnumerator LeaveCoroutine(float duration)
    {
        transform.localRotation = Quaternion.Euler(0, 0, 180);

        float f = 0;
        while (f < 1)
        {
            f += Time.deltaTime / duration;
            f = Mathf.Clamp01(f);

            transform.localPosition = (Vector3.left * f) * arriveDistance;

            yield return null;
        }
    }
}
