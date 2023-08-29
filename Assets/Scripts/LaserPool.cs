using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private List<GameObject> laserPool;
    [SerializeField] private int poolSize = 10;

    private static LaserPool instance;
    public static LaserPool Instance { get { return instance;} }
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            laserPool.Add(laser);
        }
    }

   
}
