using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    public float transition = 0.0f;
    public float animationDuration = 3.0f;
    public Vector3 animationOffset = new Vector3(0, 5, 10);
    Player player;
    

    
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*moveVector = lookAt.position + startOffset;
        //x
        moveVector.x = 0;
        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 0, 5);

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

        transform.position = moveVector  ;*/

        transform.position = new Vector3(0, animationOffset.y, player.transform.position.z + animationOffset.z);
    }
}
