// using System;
// using niscolas.UnityUtils.Core;
// using UnityEngine;
//
// public class SurfaceDetectorMB : CachedMB
// {
//     [SerializeField]
//     private LayerMask _groundMask;
//
//     [SerializeField]
//     private float _grounderOffset = -1, _grounderRadius = 0.2f;
//
//     [SerializeField]
//     private float _wallCheckOffset = 0.5f, _wallCheckRadius = 0.05f;
//
//     public event Action TouchedGround;
//
//     private readonly Collider[] _ground = new Collider[1];
//     private readonly Collider[] _leftWall = new Collider[1];
//     private readonly Collider[] _rightWall = new Collider[1];
//
//     public bool IsAgainstLeftWall { get; private set; }
//
//     public bool IsAgainstRightWall { get; private set; }
//
//     public bool PushingLeftWall { get; private set; }
//
//     public bool PushingRightWall { get; private set; }
//
//     public bool IsGrounded { get; private set; }
//
//     private void FixedUpdate()
//     {
//         HandleGrounding();
//     }
//
//     private void OnDrawGizmos()
//     {
//         DrawGrounderGizmos();
//     }
//
//     private void HandleGrounding()
//     {
//         // Grounder
//         var grounded = Physics.OverlapSphereNonAlloc(transform.position + new Vector3(0, _grounderOffset),
//             _grounderRadius, _ground, _groundMask) > 0;
//
//         if (!IsGrounded && grounded)
//         {
//             IsGrounded = true;
//             _hasJumped = false;
//             _currentMovementLerpSpeed = 100;
//             PlayRandomClip(_landClips);
//             _anim.SetBool("Grounded", true);
//             TouchedGround?.Invoke();
//             transform.SetParent(_ground[0].transform);
//         }
//         else if (IsGrounded && !grounded)
//         {
//             IsGrounded = false;
//             _timeLeftGrounded = Time.time;
//             _anim.SetBool("Grounded", false);
//             transform.SetParent(null);
//         }
//
//         // Wall detection
//         IsAgainstLeftWall = Physics.OverlapSphereNonAlloc(transform.position + new Vector3(-_wallCheckOffset, 0),
//             _wallCheckRadius, _leftWall, _groundMask) > 0;
//         IsAgainstRightWall = Physics.OverlapSphereNonAlloc(transform.position + new Vector3(_wallCheckOffset, 0),
//             _wallCheckRadius, _rightWall, _groundMask) > 0;
//         PushingLeftWall = IsAgainstLeftWall && _inputs.X < 0;
//         PushingRightWall = IsAgainstRightWall && _inputs.X > 0;
//     }
//
//     private void DrawGrounderGizmos()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position + new Vector3(0, _grounderOffset), _grounderRadius);
//     }
// }