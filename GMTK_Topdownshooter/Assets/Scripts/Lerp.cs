using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{

public float targetScale;
public float timeToLerp;
float scaleModifier = 1;

void Start()
  {
    //StartCoroutine(LerpFunction(targetScale, timeToLerp));
  }

  public IEnumerator LerpFunction(float endValue, float duration)
  {
    float time = 0;
    float startValue = scaleModifier;
    Vector3 startScale = transform.localScale;

    while (time < duration)
    {
      scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
      transform.localScale = startScale * scaleModifier;
      time += Time.deltaTime;
      yield return null;
    }
    transform.localScale = startScale * targetScale;
    scaleModifier = targetScale;
  }
}
