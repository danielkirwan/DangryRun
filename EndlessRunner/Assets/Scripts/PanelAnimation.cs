using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator PlayAnimation(float time)
    {
        yield return new WaitForSeconds(1f);
        LeanTween.init(800);
        //LeanTween.moveY(gameObject, 0, 1).setEaseOutBounce();
        //LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 1f).setDelay(1f);

        //LeanTween.scale(gameObject.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale * 2f, 1f).setDelay(1f);

        LeanTween.scaleX(gameObject, 1, 1);
        LeanTween.scaleY(gameObject, 1, 1);
    }

}
