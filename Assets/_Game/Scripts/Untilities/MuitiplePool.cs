using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Bullet,
    None
}
public class MuitiplePool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject poolPrefab;
        public int counts;
        public bool canGrow;
        public PoolType type;
    }

    public List<Pool> listPools = new List<Pool>();
}
