using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrl : MonoBehaviour
{
    public Transform PlayerTrsf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerTrsf.position.x, PlayerTrsf.position.y, -10);
    }
}
