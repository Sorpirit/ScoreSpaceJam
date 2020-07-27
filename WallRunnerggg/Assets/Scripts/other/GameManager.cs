using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enviroment;
    private GameObject go;
    public CanvasGroup blackPanel;
    public CanvasGroup MainPanel;
    public GameObject Player;

    private void Update()
    {
        if (go.transform.position.y <= 21)
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
        LeanTween.alphaCanvas(blackPanel, 0, 1);
        LeanTween.alphaCanvas(MainPanel, 1, 1f);
    }
    public void startGame()
    {
        LeanTween.alphaCanvas(MainPanel, 0, .5f);
        MainPanel.gameObject.SetActive(false);
        Player.transform.position = new Vector3(0, 40f, -5.54f);
    }

}
