using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(800);
        LeanTween.moveX(gameObject, 0, 2).setEaseOutBounce();

        //LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0f, 1f).setDelay(1f);
        //LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1f, 1f).setDelay(2f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
