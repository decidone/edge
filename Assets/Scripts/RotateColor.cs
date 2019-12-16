using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateColor : MonoBehaviour
{
    public float time;
    float colorstep;
    Color[] colors = new Color[6];
    int i;

    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.red;
        colors[1] = Color.yellow;
        colors[2] = Color.green;
        colors[3] = Color.cyan;
        colors[4] = Color.magenta;
        colors[5] = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorstep < time)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(colors[i], colors[i + 1], colorstep);
            colorstep += 0.02f;
        }
        else
        {
            colorstep = 0;
            if (i < (colors.Length - 2))
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }
}
