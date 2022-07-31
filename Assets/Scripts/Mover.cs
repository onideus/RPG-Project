using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent _agent;
    private PlayerControls _controls;
    private Animator _anim;
    private Camera _cam;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _controls = new PlayerControls();
        _anim = GetComponent<Animator>();
        _cam = Camera.main;
    }

    // private void Update()
    // {
    //     _agent.destination = target.position;
    // }

    private void OnClickToMove()
    {
        MoveToRay();
    }

    private void MoveToRay()
    {
        var ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        var hasHit = Physics.Raycast(ray, out var hit);

        if (!hasHit) return;

        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1f);
        _agent.destination = hit.point;
        // _anim.SetBool(IsWalking, true);
    }
}
