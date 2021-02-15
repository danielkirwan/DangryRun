using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(800);
        //LeanTween.moveY(gameObject, 0, 1).setEaseOutBounce();
        LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 1f).setDelay(1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
