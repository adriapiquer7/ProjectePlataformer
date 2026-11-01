using UnityEngine;

public class SpawnEnemics : MonoBehaviour
{
   
   [SerializeField]
    private float _tempsEntreSpawn;
    [SerializeField]
    private Transform _transformSpawn;

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private float _rangPositiuX = 0;
    [SerializeField]
    private float _rangNegatiuX = 0;

    private float _time = 0;
    private bool _actiu = false;

    [SerializeField]
    private int _maximEnemics = 10;

    private int _cantEnemics = 0;

    private void Spawn() {

        _cantEnemics++;
        Debug.Log("Cantidad de enemics: " + _cantEnemics);


        _time -= _tempsEntreSpawn;
        GameObject EnemicInstanciat = Instantiate(_prefab);
        EnemicInstanciat.transform.position = new Vector3(Random.Range(_transformSpawn.position.x-_rangNegatiuX, _transformSpawn.position.x+_rangPositiuX),transform.position.y,0);

    }

    public void EnemigoEliminado()
    {
        _cantEnemics--;
    }

    void Update()
    {
        if(!_actiu)
        return;

        _time += Time.deltaTime;
        if(_time > _tempsEntreSpawn && _cantEnemics < _maximEnemics)
        {
            _time=0;
            Spawn();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _actiu=true;
            _time=_tempsEntreSpawn;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _actiu=false;
        }
    }


}
