using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
   public Sprite platformSprite;
   public GameObject platformPrefab;
   public List<PlatformInfo> level;

    public int minSizeValue = 2;
    public int maxSizeValue = 10;

    public Vector3 lastPlatformPosition;
   
   public void Start()
   {
       //Creating list of all level platforms
       level = new List<PlatformInfo>();
       //Setup starting position for first platform
       lastPlatformPosition = new Vector3(0,0,0);
       SetupLevelInfo(5);
       CreateWorld(level);
   }

   public void SetupLevelInfo(int _platformsAmount)
   {
       for(int i = 0 ; i< _platformsAmount; i++)
       {
          level.Add(CreatePlatformInfo());
          if(i < 0)
          {
              if(level[i].position.x - level[i-1].position.x <= 3)
              {
                  level[i-1].isMovable = true;
              }
          }
            Debug.Log("Platfrom Info " + "length: " + level[i].length + " Heigth " + level[i].heigth + "Position " + level[i].position);
       }
   }

    public PlatformInfo CreatePlatformInfo()
    {
        int platformLength = Random.Range(minSizeValue, maxSizeValue);
        int platformHeigth = Random.Range(minSizeValue, maxSizeValue);
        float platformFloor = Random.Range(1, 5);
        Vector3 platformPosition = new Vector3(lastPlatformPosition.x + Random.Range(0, 10), platformFloor, 0);
        PlatformInfo newInfo= new PlatformInfo(platformLength, platformHeigth, false, lastPlatformPosition);
        newInfo.AdjustPlatformSize();
        lastPlatformPosition += platformPosition;
        return newInfo;
    }

    public void CreateWorld(List<PlatformInfo> _levelInfo)
    {
        
        for(int i=0; i< _levelInfo.Count; i++)
        {
            Instantiate(platformPrefab,_levelInfo[i].position, Quaternion.identity);
        }
    }
}