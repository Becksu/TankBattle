using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UILose : MonoBehaviour
{
    public Text textScore;
    public Button bntsHome;
    public CanvasGroup group;
    void Start()
    {
        group.alpha = 0;
        bntsHome.onClick.AddListener(HomeUI);
        textScore.text = LevelManager.Instance.player.score.ToString();
        group.DOFade(1, 1f);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 1f).SetEase(Ease.OutBounce);
        GameManager.Instance.ChanggGameState(GameState.GameLose);
    }
    public void HomeUI()
    {
        UIManager.uIMainMenu.gameObject.SetActive(true);
        UIManager.uIMainMenu.gameObject.transform.localPosition = Vector3.zero;
        GameManager.Instance.ChanggGameState(GameState.MainMenu);
        LevelManager.Instance.ResetGame();
        Destroy(gameObject);
    }
}
