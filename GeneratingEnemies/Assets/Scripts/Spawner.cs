using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _petTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_petTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pet))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetPet(pet, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetPet(GameObject pet, Vector3 spawnPoint)
    {
        pet.SetActive(true);
        pet.transform.position = spawnPoint;
    }
}
