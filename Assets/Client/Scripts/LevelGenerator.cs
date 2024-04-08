using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tileGrounds;
    [SerializeField] private int _tileLength;

    private List<GameObject> _currentTileGrounds = new List<GameObject>();
    private Vector3 _nextSpawn = Vector3.zero;

    [ContextMenu("Add tale")]
    private void AddTale()
    {
        int indexTale = Random.Range(0, _tileGrounds.Length);
        _currentTileGrounds.Add(Instantiate(_tileGrounds[indexTale], _nextSpawn, Quaternion.identity));
        _nextSpawn.z += _tileLength;
    }
}
