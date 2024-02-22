using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowScript : MonoBehaviour
{

    public GameObject player;

    public float minX, maxX;
    private Vector3 v;
    private Camera camera;
    private float halfHeight;
    private float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        halfHeight = camera.orthographicSize;
        screenWidth = camera.aspect * halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
      v = player.transform.position;
      v.z -= 10;
      if (v.x < minX + screenWidth)
      {
        v.x = minX + screenWidth;
      }
      if (v.x > maxX - screenWidth)
      {
        v.x = maxX - screenWidth;
      }
      transform.position = v;
    }
}
