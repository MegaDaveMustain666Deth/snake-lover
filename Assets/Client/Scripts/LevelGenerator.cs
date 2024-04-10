using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] _tileGrounds;
    [SerializeField] private GameObject[] _backgroundObjects;
    [SerializeField] private int _tileLength;
    [SerializeField] private int _amoutTileForAdding;
    [SerializeField] private int _amoutObjectForAdding;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private float _minDistanceBetweenObjects;
    [SerializeField] private float _maxDistanceBetweenObjects;
    [SerializeField] private Transform _startSpawnObjects;

    private Queue<GameObject> _currentTileGrounds = new Queue<GameObject>();
    private Queue<GameObject> _currentBackgroundObjects = new Queue<GameObject>();
    private float _deleteTile;
    private float _deleteObject;
    private Transform _player;

    private void Start()
    {
        _player = Snake.Instance.transform;
        _currentTileGrounds.Clear();
        _currentBackgroundObjects.Clear();
        for(int i = 0; i < _amoutTileForAdding; i++)
        {
            AddTile();
        }
        for(int i = 0; i < _amoutObjectForAdding; i++)
        {
            AddBackgroundObjects();
        }
    }

    [ContextMenu("Add obj")]
    private void AddBackgroundObjects()
    {
        float spawnObj = Random.Range(_minDistanceBetweenObjects, _maxDistanceBetweenObjects);
        int indexTale = Random.Range(0, _backgroundObjects.Length);
        _currentBackgroundObjects.Enqueue(Instantiate(_backgroundObjects[indexTale], _startSpawnObjects.position, Quaternion.identity));
        _startSpawnObjects.position += new Vector3(0, 0, spawnObj);
        _deleteObject = _startSpawnObjects.position.z - (spawnObj * _amoutObjectForAdding) + _minDistanceBetweenObjects;
    }

    [ContextMenu("Add tile")]
    private void AddTile()
    {
        int indexTale = Random.Range(0, _tileGrounds.Length);
        _currentTileGrounds.Enqueue(Instantiate(_tileGrounds[indexTale], _startSpawn.position, Quaternion.identity));
        _startSpawn.position += new Vector3(0, 0, _tileLength);
        _deleteTile = _startSpawn.position.z - (_tileLength * _amoutTileForAdding) + 34;
    }

    [ContextMenu("Add tddile")]
    private void DeletePreviousTile()
    {
        Destroy(_currentTileGrounds.Dequeue());
    }

    private void DeletePreviousObj()
    {
        Destroy(_currentBackgroundObjects.Dequeue());
    }

    private void Update()
    {
        if(_player.position.z > _deleteTile)
        {
            AddTile();
            DeletePreviousTile();
        }
        if(_player.position.z > _deleteObject)
        {
            AddBackgroundObjects();
            DeletePreviousObj();
        }
    }
}
