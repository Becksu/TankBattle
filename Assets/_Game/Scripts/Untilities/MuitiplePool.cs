using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Bullet,
    Bot,
    None
}
public class MuitiplePool : Singleton<MuitiplePool>
{
    [System.Serializable]
    public class Pool
    {
        public GameObject poolPrefab;
        public int counts;
        public bool canGrow;
        public PoolType type;
        public Transform parents;
    }
    public List<Pool> listPools = new List<Pool>();
    private Dictionary<PoolType, Queue<GameObject>> dictionPool = new Dictionary<PoolType, Queue<GameObject>>();

    private void Awake()
    {
        
        foreach(Pool pool in listPools)
        {
            Queue<GameObject> gameObjects = new Queue<GameObject>();
            for(int i = 0; i < pool.counts; i++)
            {
                GameObject go = Instantiate(pool.poolPrefab, pool.parents);
                go.SetActive(false);
                gameObjects.Enqueue(go);
            }
            dictionPool.Add(pool.type, gameObjects);
        }
    }

    public GameObject GetGameObject(PoolType type,Vector3 pos)
    {
        for(int i = 0; i < listPools.Count; i++)
        {
            if (listPools[i].type == type)
            {
                if (dictionPool[type].Count > 0)
                {
                    GameObject go = dictionPool[type].Dequeue();
                    go.gameObject.SetActive(true);
                    go.transform.position = pos;
                    return go;
                }
                else if (listPools[i].canGrow)
                {
                    GameObject go = Instantiate(listPools[i].poolPrefab, listPools[i].parents);
                    go.transform.position = pos;
                    return go;
                }
                else return null;
            }
        }
        return null;
    }

    public void ReturnGameObject(PoolType type,GameObject go)
    {
        go.gameObject.SetActive(false);
        dictionPool[type].Enqueue(go); 
    }
}
