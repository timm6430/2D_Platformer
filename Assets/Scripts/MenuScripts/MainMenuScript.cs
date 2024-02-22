using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
  private float buffer = 0, buffer2 = 0 ;
  private bool bottom = false, fade = false;
  private Color tempColor;
  private Light l;
  private Camera c;
  private Color skyColor;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 40f, -10f);
        l = GameObject.Find("Area Light").GetComponent<Light>();
        c = GameObject.Find("Main Camera").GetComponent<Camera>();
        skyColor = c.backgroundColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      if (buffer < 150)  
      {
        buffer++;
      }
      else
      {

        if (transform.position[1] <-85f)
        {
          buffer2 ++;
          if (buffer2 > 500)
          {
            buffer = 0;
            buffer2 = 0;
            transform.position  = new Vector3(0f, 40f, -10f);
            c.backgroundColor = skyColor;
            l.intensity = 1;
          }
        }
        else
        {
         transform.position = transform.position - new Vector3(0f, 0.01f, 0f);  
        }
        if (transform.position[1] < -35f)
        {
          Debug.Log(c.backgroundColor);
          c.backgroundColor = Color.Lerp(c.backgroundColor, Color.black, 0.003f);
          
          if (l.intensity > 0)
          {
            l.intensity -= 0.001f;
          }
        }
      }
    }

    
}
