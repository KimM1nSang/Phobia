using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public PlayerInput input;
    public Transform viewPoint;

    private float time;
    private float yMove = 0;
    public float interval = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (input.frontMove != 0 || input.rightMove !=0)
        {
            time += Time.deltaTime * 10;
            yMove = Mathf.Sin(time)*interval;
            transform.position = new Vector3(viewPoint.transform.position.x, viewPoint.transform.position.y+yMove, viewPoint.transform.position.z);
        }
    }
}
