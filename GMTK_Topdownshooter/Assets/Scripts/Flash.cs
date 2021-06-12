using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public float flashTime;
    Color origionalColor;
    public SpriteRenderer renderer;
    
    void Start()
    {
        origionalColor = renderer.color;
    }
 
    public void FlashRed()
    {
        renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
 
    void ResetColor()
    {
        renderer.color = origionalColor;
    }
}
