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

    // ��ġ�� ������ �� �ִ� ������Ʈ�� �����ϱ� ���� �迭
    // Vehicle ������Ʈ�� ������ �� �ִ� �迭

    // ���� ������Ʈ�� �����ϰ� List�� �����մϴ�.
    // ���� ������Ʈ�� ��Ȱ��ȭ �� ���·� �����մϴ�.
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

            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                while (vehicleList[random].activeSelf == true)
                {
                    random = (random + 1) % vehicleList.Count;
                }

                // �������� ��ġ�� �����ϴ� ������ �����մϴ�.
                randomPosition = Random.Range(0, spawnPosition.Length);

                // ������ ����Ǿ� �ִ� ������ �������� ������ �ٽû̽��ϴ�
                while (randomPosition == lastPosition)
                {
                    randomPosition = Random.Range(0, spawnPosition.Length);
                }
                lastPosition = randomPosition;

                // vehicle ������Ʈ�� �����Ǵ� ��ġ�� �������� �����մϴ�.
                vehicleList[random].transform.position = spawnPosition[randomPosition].position;

                // �������� ������ vehicle ������Ʈ�� Ȱ��ȭ �մϴ�.
                vehicleList[random].SetActive(true);
            }
    
            // vehicleList.Capacity ����

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