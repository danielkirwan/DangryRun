using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(800);
        LeanTween.moveY(gameObject, -189, 1).setEaseOutBounce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
