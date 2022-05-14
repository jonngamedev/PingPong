using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] GameObject lifeBar;
    [SerializeField] GameObject heartPrefab;

    List<GameObject> lifeHeart = new List<GameObject>();

    private void GetLifeObjects()
    {
        Transform[] bufferArray = lifeBar.GetComponentsInChildren<Transform>();

        for (int lifeIndex = 1; lifeIndex < bufferArray.Length; lifeIndex++)
        {
            lifeHeart.Add(bufferArray[lifeIndex].gameObject);
        }
    }


    public void AddLifePrefabs(int numberOfHearts)
    {
        for (int index = 0; index < numberOfHearts; index++)
        {
            Instantiate(heartPrefab, lifeBar.transform);
        }

        GetLifeObjects();
    }

    public void RefillHealthBar() 
    {
        for (int lifeIndex = 0; lifeIndex < lifeHeart.Count; lifeIndex++)
        {
            lifeHeart[lifeIndex].SetActive(true);
        }
    }

    public void TakeLife()
    {
        for (int lifeIndex = 0; lifeIndex < lifeHeart.Count; lifeIndex++)
        {
            if (lifeHeart[lifeIndex].activeSelf)
            {
                lifeHeart[lifeIndex].SetActive(false);
                break;
            }
        }
    }
}
