using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tileGrounds;
    [SerializeField] private int _tileLength;
    [SerializeField] private Transform _target;
    [SerializeField] private int _amoutTileForAddingTile;
    [SerializeField] private Transform _startSpawn;

    private Queue<GameObject> _currentTileGrounds = new Queue<GameObject>();
    private float _deleteTile;

    private void Start()
    {;
        _currentTileGrounds.Clear();
        for(int i = 0; i < _amoutTileForAddingTile; i++)
        {
            AddTile();
        }
    }

    [ContextMenu("Add tile")]
    private void AddTile()
    {
        int indexTale = Random.Range(0, _tileGrounds.Length);
        _currentTileGrounds.Enqueue(Instantiate(_tileGrounds[indexTale], _startSpawn.position, Quaternion.identity));
        _startSpawn.position += new Vector3(0, 0, _tileLength);
        _deleteTile = _startSpawn.position.z - (_tileLength * _amoutTileForAddingTile) + 34;
    }

    [ContextMenu("Add tddile")]
    private void DeletePreviousTile()
    {
        Destroy(_currentTileGrounds.Dequeue());
    }

    private void Update()
    {
        if(_target.position.z > _deleteTile)
        {
            AddTile();
            DeletePreviousTile();
        }
    }
}
