using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnimation : MonoBehaviour
{
    private float time = 2f;


    private float currentTime =0f;
    private float delayTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > currentTime)
        {
            StartCoroutine(PlayAnimation(1f));   
        } 
    }


    IEnumerator PlayAnimation(float time)
    {
        yield return new WaitForSeconds(1f);
        currentTime = Time.time + delayTime;
        LeanTween.init(800);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0f, 1f);
        StartCoroutine(ReverseAnimation(1f));
    }

    IEnumerator ReverseAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        LeanTween.init(800);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1f, 1f);

    }
}
