using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int count;
    [SerializeField] Transform[] spawnPosition;
    [SerializeField] GameObject[] vehicleObject;
    
    [SerializeField] List<GameObject> vehicleList;

    // 위치를 저장할 수 있는 오브젝트를 저장하기 위한 배열
    // Vehicle 오브젝트를 저장할 수 있는 배열

    // 게임 오브젝트를 생성하고 List에 저장합니다.
    // 게임 오브젝트를 비활성화 한 상태로 저장합니다.
    void Start()
    {
        vehicleList.Capacity = 20;
        Create();
        StartCoroutine(ActiveVehicle());
    }

    public void Create()
    {
        for(int i = 0; i<vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i]);
            
            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            random = Random.Range(0, vehicleObject.Length);

            while (vehicleList[random].activeSelf == true)
            {
                count++;
                if (count >= vehicleObject.Length)
                {
                    yield break;
                }

                random = (random + 1) % vehicleList.Count;
            }

            vehicleList[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }
}
