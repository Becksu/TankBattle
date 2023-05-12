using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWin : MonoBehaviour
{
    public Text textScore;
    public Button bntsHome;
    public ParticleSystem fxFireWork;
    void Start()
    {
        bntsHome.onClick.AddListener(HomeUI);
        textScore.text = LevelManager.Instance.player.score.ToString();
        fxFireWork.Play();
    }
    public void HomeUI()
    {
        UIManager.uIMainMenu.gameObject.SetActive(true);
        GameManager.Instance.ChanggGameState(GameState.MainMenu);
        LevelManager.Instance.ResetGame();
        Destroy(gameObject);
    }
}
