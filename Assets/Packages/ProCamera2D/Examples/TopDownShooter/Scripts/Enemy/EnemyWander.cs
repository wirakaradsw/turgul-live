﻿using UnityEngine;
using System.Collections;

namespace Com.LuisPedroFonseca.ProCamera2D.TopDownShooter
{
    public class EnemyWander : MonoBehaviour
    {
        public float WanderDuration = 10; // 0 to loop
        public float WaypointOffset = .1f;
        public float WanderRadius = 10f;

        UnityEngine.AI.NavMeshAgent _navMeshAgent;
        bool _hasReachedDestination;
        Vector3 _startingPos;
        float _startingTime;

        void Awake ()
        {
            _navMeshAgent = this.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            _startingPos = _navMeshAgent.transform.position;
        }

        public void StartWandering()
        {
            _startingTime = Time.time;
            GoToWaypoint();
            StartCoroutine(CheckAgentPosition());
        }

        public void StopWandering()
        {
            StopAllCoroutines();
        }

        IEnumerator CheckAgentPosition()
        {
            while(true)
            {
                if (_navMeshAgent.remainingDistance <= WaypointOffset && !_hasReachedDestination)
                {
                    _hasReachedDestination = true;

                    if(Time.time - _startingTime >= WanderDuration && WanderDuration > 0)
                    {
                        // Dispatch complete event
                        Debug.Log("Stopped wandering");
                    }
                    else
                    {
                        GoToWaypoint();
                    }
                }

                yield return null;
            }
        }

        void GoToWaypoint()
        {
            UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
            Vector3 newLocation = Vector3.zero;
            while (path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial || path.status == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
            {
                Vector3 ran = Random.insideUnitSphere * WanderRadius;
                ran.y = _startingPos.y;
                newLocation = _startingPos + ran;
                _navMeshAgent.CalculatePath(newLocation, path);
            }
            _navMeshAgent.SetDestination(newLocation);

            _hasReachedDestination = false;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.matrix = Matrix4x4.TRS(Application.isPlaying ? _startingPos : transform.position, Quaternion.identity, new Vector3(1f, 0f, 1f));
            Gizmos.DrawWireSphere(Vector3.zero, WanderRadius);
        }
    }
}