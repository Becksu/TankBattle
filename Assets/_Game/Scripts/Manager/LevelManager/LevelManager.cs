using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ColorTypeData colorData;
    public Player player;
    public int coint;
    public int characterCounts;
    public int countDie;
    public int idCharacter;
    private List<Character> characters = new List<Character>();
    void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        GetPlayer();
        GetBot();
    }
    public void GetPlayer()
    {
        float randomX = Random.Range(-72f, 73f);
        float randomZ = Random.Range(-72f, 73f);
        player.transform.position = new Vector3(randomX, 0, randomZ);
        idCharacter = 0;
        player.characterID = idCharacter;
        player.OnInit();
        idCharacter++;
    }
    public void GetBot()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnerBot();
        }
    }
    public void SpawnerBot()
    {
        if (characterCounts > characters.Count)
        {
            float randomX = Random.Range(-72f, 72f);
            float randomZ = Random.Range(-72f, 72f);
            Vector3 pos = new Vector3(randomX, 0, randomZ);
            GameObject character = MuitiplePool.Instance.GetGameObject(PoolType.Bot, pos);
            Character charac = character.GetComponent<Character>();
            charac.characterID = idCharacter;
            charac.OnInit();
            characters.Add(charac);
            idCharacter++;
        }
    }
    public void DespawnCharacter()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            MuitiplePool.Instance.ReturnGameObject(PoolType.Bot, characters[i].gameObject);
        }
        characterCounts = 20;
        characters.Clear();
    }


    public void WinGame()
    {
        UIManager parents = FindObjectOfType<UIManager>();
        GameObject go = Resources.Load<GameObject>("UI/Canvas-Win");
        GameObject gameObject = Instantiate(go, parents.transform);
    }
    public void LoseGame()
    {
        UIManager parents = FindObjectOfType<UIManager>();
        GameObject go = Resources.Load<GameObject>("UI/Canvas-Lose");
        GameObject gameObject = Instantiate(go, parents.transform);
        UIMainMenu.uIGamePlay.gameObject.SetActive(false);
    }
    public void ResetGame()
    {
        DespawnCharacter();
        OnInit();
    }
}
