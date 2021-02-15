using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatUpText : MonoBehaviour
{

    Text upText;
    float alpha = 1;

    // Start is called before the first frame update
    void Start()
    {
        upText = this.GetComponent<Text>();
        upText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 20, 0);
        alpha -= 0.05f;
        upText.color = new Color(upText.color.r, upText.color.g, upText.color.b, alpha);

        if(alpha < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
