using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CasterBehavior))]
public class PlayerBehavior : MonoBehaviour
{
    public Camera FollowCamera;
    private Vector3 _cameraOffset;

    private NavMeshAgent _agent;
    private CasterBehavior _caster;

    // Start is called before the first frame update
    void Start() {
        if (FollowCamera) {
            _cameraOffset = FollowCamera.transform.position;
        }
        _agent = GetComponent<NavMeshAgent>();
        _caster = GetComponent<CasterBehavior>();
    }

    // Update is called once per frame
    void Update() {
        // Move the camera
        if (FollowCamera) {
            FollowCamera.transform.position = transform.position + _cameraOffset;
        }

        // Find the direction
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // Move
        _agent.destination = transform.position + direction;

        // Hard set the facing
        //HardFace(direction);

        // Cast spell
        if (_caster.Spell1 && Input.GetButtonDown("Fire1") && _agent.speed != 0.0f) {
            _caster.StartCast(_caster.Spell1);
            HardFace(direction);
        }
        if (_caster.Spell2 && Input.GetButtonDown("Fire2") && _agent.speed != 0.0f) {
            _caster.StartCast(_caster.Spell2);
            HardFace(direction);
        }
        if (_caster.Spell3 && Input.GetButtonDown("Fire3") && _agent.speed != 0.0f) {
            _caster.StartCast(_caster.Spell3);
            HardFace(direction);
        }
    }

    public void HardFace(Vector3 direction) {
        if (direction.magnitude > 0)
            transform.forward = direction;
    }
}
