using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGamePlay : Singleton<UIGamePlay>
{
    public static UIPause uiPause;
    public Text textScore;
    private void Start()
    {
        SetScoreText();
    }
    public void PauseUI()
    {
        if (uiPause == null)
        {
            UIManager parents = FindObjectOfType<UIManager>();
            GameObject gameObject = Resources.Load<GameObject>("UI/Canvas-Pause");
            GameObject game = Instantiate(gameObject, parents.transform);
            uiPause = game.GetComponent<UIPause>();

        }
        else
        {
            uiPause.gameObject.SetActive(true);
        }
        uiPause.transform.localPosition = new Vector3(0, 1550, 0);
        uiPause.transform.DOLocalMoveY(0, 1f, false).SetEase(Ease.InOutSine).OnStart(() =>
        {
            uiPause.OnInitUIPause();
        }).OnComplete(() =>
        {
            uiPause.transform.DOPunchPosition(uiPause.transform.localPosition + Vector3.up * 20f, 1f, 3);
            Invoke(nameof(DespawnUIGamePlay), 1f);
        });
        GameManager.Instance.ChanggGameState(GameState.GamePause);
        gameObject.SetActive(false);
       
    }
    public void SetScoreText()
    {
        textScore.text = LevelManager.Instance.player.score.ToString();
    }
    public void DespawnUIGamePlay()
    {
        uiPause.bntsContinue.interactable = true;
        uiPause.bntsMainMenu.interactable = true;
        Time.timeScale = 0;
    }
}
