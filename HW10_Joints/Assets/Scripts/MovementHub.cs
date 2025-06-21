using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MovementHub : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    private Vector3 _currentTarget;
    private int _currentIndex = 0;

    private void Start()
    {   
        _currentTarget = _points[0].position;
    }

    // Update is called once per frame
    private void Update()
    {
        //��� ������� ���, ����� ��������� ������ ��������� ������ ������ ������ transform.right?
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
        transform.LookAt(_currentTarget);
        if (transform.position.x - _currentTarget.x == 0) //������ ��� ������ ������ �������� Vector3.Distance() == 0 ?
        {
            _currentIndex = (_currentIndex + 1) % _points.Length;
            _currentTarget = _points[_currentIndex].position;
        }
    }
}
