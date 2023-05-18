using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPause : MonoBehaviour
{
    public Button bntsContinue;
    public Button bntsMainMenu;
    public Button bntsQuit;
    void Start()
    {
        bntsContinue.onClick.AddListener(ContinueUI);
        bntsMainMenu.onClick.AddListener(MainMenuUI);
        bntsQuit.onClick.AddListener(QuitUI);
    }
    public void OnInitUIPause()
    {
        bntsMainMenu.interactable = false;
        bntsContinue.interactable = false;
    }
    public void ContinueUI()
    {

        Time.timeScale = 1;
        transform.DOLocalMoveY(1500, 1f, false).SetEase(Ease.InOutSine);
        Invoke(nameof(DespawnUIPauseFromContinue), 1f);
    }
    public void MainMenuUI()
    {
        Time.timeScale = 1;
        UIManager.uIMainMenu.gameObject.SetActive(true);
        UIManager.uIMainMenu.transform.DOLocalMoveX(0, 1f, false).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            UIManager.uIMainMenu.transform.DOPunchPosition(UIManager.uIMainMenu.transform.localPosition + Vector3.left * 20f, 1f, 3);
        });
        transform.DOLocalMoveX(1500, 1f, false);
        Invoke(nameof(DespawnUIPauseFromMainMenu), 1f);
    }
    public void QuitUI()
    {
        Application.Quit();
    }
    public void DespawnUIPauseFromContinue()
    {
        GameManager.Instance.ChanggGameState(GameState.Gameplay);
        UIMainMenu.uIGamePlay.gameObject.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void DespawnUIPauseFromMainMenu()
    {

        gameObject.SetActive(false);
        GameManager.Instance.ChanggGameState(GameState.MainMenu);
        LevelManager.Instance.ResetGame();
    }
}
