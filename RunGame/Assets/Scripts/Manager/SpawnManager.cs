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

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            int lastPosition = Random.Range(0, spawnPosition.Length);

            for (int i = 0; i < Random.Range(1,3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

            while (vehicleList[random].activeSelf == true)
            {
                random = (random + 1) % vehicleList.Count;
            }

                // 랜덤으로 위치를 설정하는 변수를 선업합니다.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // 이전에 저장되어 있던 변수와 랜덤값이 같으면 다시뽑습니다
                while(randomPosition == lastPosition)
                {
                    randomPosition = Random.Range(0, spawnPosition.Length);
                }
                lastPosition = randomPosition;

                // vehicle 오브젝트가 생선되는 위치를 랜덤으로 설정합니다.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // 랜덤으로 설정된 vehicle 오브젝트를 활성화 합니다.
                vehicleList[random].SetActive(true);
            }
            // vehicleList.Capacity 증가

            if(CheckSet() == true)
            {
                Create();
            }

            yield return new WaitForSeconds(5);
        }
    }

    public bool CheckSet()
    {
        for(int i = 0; i<vehicleList.Count;i++) 
        {
            if (vehicleList[i].activeSelf == false)
                return false;
        }
        return true;
    }
}
