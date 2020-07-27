using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enviroment;
    private GameObject go;

    private void Update()
    {
        if (go.transform.position.y <= 20)
        {
            spawn();
        }
    }
    private void spawn()
    {
        go = Instantiate(Enviroment);
    }
    private void Start()
    {
        spawn();
    }
}
