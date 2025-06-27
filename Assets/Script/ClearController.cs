using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearController : MonoBehaviour
{
    private bool gameClear;
    public GameObject winnerLabelObject;
    public GameObject gameClearLabel;
    public GameObject GameController;
    private GameController gameController;


void Start()
{
     gameController = GameController.gameObject.GetComponent<GameController>();
}
private void OnTriggerEnter(Collider other)
{
    if(other.gameObject.tag == "GameClear" && gameController.totalItems == 0)
    {
        // gameClear = true;
        winnerLabelObject.SetActive(true);
        gameClearLabel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
}
