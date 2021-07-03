using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private Vector3 originalPos;
    private float timeAtCurrentFrame;
    private float timeAtLastFrame;
    private float fakeDelta;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //Calculate a fake delta time, so we can Shake while game is paused.
        timeAtCurrentFrame = Time.realtimeSinceStartup;
        fakeDelta = timeAtCurrentFrame - timeAtLastFrame;
        timeAtLastFrame = timeAtCurrentFrame;
    }

    public static void Shake(float duration, float amount)
    {
        instance.originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.CShake(duration, amount));
    }

    public IEnumerator CShake(float duration, float amount)
    {
        while (duration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= fakeDelta;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
