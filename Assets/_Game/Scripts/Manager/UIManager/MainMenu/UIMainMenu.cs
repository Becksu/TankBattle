using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIMainMenu : Singleton<UIMainMenu>
{

    public Button bntsPlay;
    public Button bntsOption;
    public Button bntsLeaderboard;
    public Button bntsQuit;
    public static UIGamePlay uIGamePlay;
    private void Start()
    {
        bntsPlay.onClick.AddListener(BntsPlay);
        bntsOption.onClick.AddListener(BntsOption);
        bntsLeaderboard.onClick.AddListener(BntsLeaderboard);
        bntsQuit.onClick.AddListener(BntsQuit);
    }
    public void BntsPlay()
    {
        
        if(uIGamePlay == null)
        {
            UIManager parents = FindObjectOfType<UIManager>();
            GameObject gameObject = Resources.Load<GameObject>("UI/Canvas-GamePlay");
            GameObject uiGame = Instantiate(gameObject,parents.transform);
            uIGamePlay = uiGame.GetComponent<UIGamePlay>();
            LevelManager.Instance.player.joystick = FindObjectOfType<JoystickControler>();
        }
        else
        {
            uIGamePlay.gameObject.SetActive(true);
        }
        uIGamePlay.transform.localPosition = new Vector3(1500f, 0, 0);
        uIGamePlay.transform.DOLocalMove(Vector3.zero, 1f, false).SetEase(Ease.InOutSine).OnComplete(() => {
            uIGamePlay.transform.DOPunchPosition(uIGamePlay.transform.localPosition+Vector3.right*20f, 1f, 3);
        });
        uIGamePlay.SetScoreText();
        transform.DOLocalMove(new Vector3(-1500,0,0), 1f, false).SetEase(Ease.InOutSine).OnComplete(() =>
        {
           transform.DOPunchPosition(transform.localPosition+Vector3.right*20f, 1f, 3);

        });
        Invoke(nameof(DespawnUIMenu), 1f);
    }
    public void BntsOption()
    {

    }
    public void BntsLeaderboard()
    {

    }
    public void Shake()
    {
        transform.DOShakePosition(3f, 50, 50);
    }
    public void BntsQuit()
    {
        Application.Quit();
    }
    public void DespawnUIMenu()
    {
        GameManager.Instance.ChanggGameState(GameState.Gameplay);
        gameObject.SetActive(false);
    }
}
