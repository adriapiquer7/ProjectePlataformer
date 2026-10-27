using UnityEngine;

public class SpawnEnemics : MonoBehaviour
{
   
   [SerializeField]
    private float _temps;

    [SerializeField]
    private GameObject _prefab;

    private float _time = 0;

    private void Spawn() {


        _time -= _temps;
        GameObject EnemicInstanciat = Instantiate(_prefab);
        EnemicInstanciat.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);

    }

    void Update()
    {
        _time += Time.deltaTime;
        if(_time > _temps)
        {
            Spawn();
        }
    }


}
