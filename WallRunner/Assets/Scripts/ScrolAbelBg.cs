 
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrolAbelBg : MonoBehaviour
{
    [SerializeField] private GameObject[] bg;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private bool testAcc;
    private float scrollAcc = 2;
    private float minY = -40f;
    private float partSize = 20f;

    private void FixedUpdate()
    {
        if (testAcc)
        {
            scrollSpeed += scrollAcc * Time.deltaTime;
            scrollSpeed = Mathf.Clamp(scrollSpeed, .1f, 120f);
        }
        

        for(int i = 0; i < bg.Length; i++)
        {
            if (bg[i].transform.position.y <= minY)
            {
                Vector3 bgNewPos = bg[i].transform.position;
                int highestPartIndex = i - 1;
                highestPartIndex = highestPartIndex < 0 ? bg.Length - 1 : highestPartIndex;
                bgNewPos.y = bg[highestPartIndex].transform.position.y + partSize;
                bg[i].transform.position = bgNewPos;
            }


            bg[i].transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        }
    }
   
}
