using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float time;
    public PlayerInput input;
    private float yMove = 0;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*10;
        if (input.frontMove != 0 || input.rightMove !=0)
        {
            yMove = Mathf.Sin(time)*0.1f;
            transform.position = new Vector3(transform.position.x,transform.parent.position.y+yMove, transform.position.z);
        }
    }
}
