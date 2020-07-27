using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goDown : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, gameObject.transform.position.y - Time.deltaTime * speed, 0);
        if (gameObject.transform.position.y <= -140)
        {
            Destroy(gameObject);
        }
    }
}
