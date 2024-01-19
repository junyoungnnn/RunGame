using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int count;
    [SerializeField] int randomPosition;

    [SerializeField] Transform[] spawnPosition;
    [SerializeField] GameObject[] vehicleObject;
    
    [SerializeField] List<GameObject> vehicleList;

    // 위치를 저장할 수 있는 오브젝트를 저장하기 위한 배열
    // Vehicle 오브젝트를 저장할 수 있는 배열

    // 게임 오브젝트를 생성하고 List에 저장합니다.
    // 게임 오브젝트를 비활성화 한 상태로 저장합니다.
    void Start()
    {
        vehicleList.Capacity = 1000;
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

    // vehicleLIst가 다 찼는지 확인하는 함수
    public bool FullVehicle()
    {
        for (int i = 0; i < vehicleList.Count; i++)
        {
            if (vehicleList[i].activeSelf == false)
                return false;
        }
        return true;
    }

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            int lastPosition = Random.Range(0, spawnPosition.Length);

            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                // 현재 게임 오브젝트가 활성화되어 있는지 확인합니다
                while (vehicleList[random].activeSelf == true)
                {
                    if (FullVehicle() == true) // 현재 리스트에 있는 모든 오브젝트가 활성화되어 있는 지 확인합니다.
                    {
                        // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                        // vehicle을 리스트에 넣어줍니다.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);
                        
                        vehicle.SetActive(false);
                        
                        vehicleList.Add(vehicle);
                    }

                    // 현재 리스트에 있는 모든 게임 오브젝트가 활성화 되어 있지 않다면
                    // random 변수의 값을 +1 해서 다시 검색합니다.
                    random = (random + 1) % vehicleList.Count;
                }

                // 랜덤으로 위치를 설정하는 변수를 선언합니다.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // 이전에 저장되어 있던 변수와 랜덤값이 같으면 다시뽑습니다
                while (randomPosition == lastPosition)
                {
                    randomPosition = Random.Range(0, spawnPosition.Length);
                }
                lastPosition = randomPosition;

                // vehicle 오브젝트가 생선되는 위치를 랜덤으로 설정합니다.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // 랜덤으로 설정된 vehicle 오브젝트를 활성화 합니다.
                vehicleList[random].SetActive(true);
            }
            yield return CoroutineCache.waitForSeconds(5f);
        }
    }
}
