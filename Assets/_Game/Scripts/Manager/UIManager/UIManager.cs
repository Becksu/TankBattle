using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIType
{
    MainMenu,
    GamePlay,
    Pause,
    Win,
    Lose,
}
public class UIManager : Singleton<UIManager>
{
    public static UIMainMenu uIMainMenu;
    void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        GameManager.Instance.ChanggGameState(GameState.MainMenu);
        GameObject go = Resources.Load<GameObject>("UI/Canvas-MainMenu");
        GameObject menu = Instantiate(go, transform);
        uIMainMenu = menu.GetComponent<UIMainMenu>();
        uIMainMenu.transform.localPosition = Vector3.zero;
    }
}
