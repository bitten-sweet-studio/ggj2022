// using System;
// using niscolas.UnityUtils.Core;
// using UnityAtoms.BaseAtoms;
// using UnityEngine;
//
// public class DasherMB : CachedMB
// {
//     [SerializeField]
//     private Rigidbody _rigidbody;
//
//     [SerializeField]
//     private MovementMB _movement;
//
//     [SerializeField]
//     private MovementInputMB _movementInput;
//
//     [SerializeField]
//     private SurfaceDetectorMB _surfaceDetector;
//
//     [Header("Settings")]
//     [SerializeField]
//     private FloatReference _dashSpeed = new FloatReference(15);
//
//     [SerializeField]
//     private FloatReference _dashLength = new FloatReference(1);
//
//     // [SerializeField]
//     // private ParticleSystem _dashParticles;
//
//     [SerializeField]
//     private Transform _dashRing;
//
//     // [SerializeField]
//     // private ParticleSystem _dashVisual;
//
//     [Header("Input")]
//     [SerializeField]
//     private BoolReference _isGrounded;
//
//     public static event Action OnStartDashing, OnStopDashing;
//
//     public bool IsDashing { get; private set; }
//     
//     private bool _hasDashed;
//     private float _timeStartedDash;
//     private Vector3 _dashDir;
//
//     private void Start()
//     {
//         _surfaceDetector.TouchedGround += SurfaceDetectorTouchedSurface;
//     }
//
//     private void FixedUpdate()
//     {
//         HandleDashing();
//     }
//
//     private void OnDestroy()
//     {
//         _surfaceDetector.TouchedGround -= SurfaceDetectorTouchedSurface;
//     }
//
//     private void SurfaceDetectorTouchedSurface()
//     {
//         _hasDashed = false;
//     }
//
//     private void HandleDashing()
//     {
//         if (Input.GetKeyDown(KeyCode.X) && !_hasDashed)
//         {
//             _dashDir = new Vector3(_movementInput.RawX, _movementInput.RawY).normalized;
//
//             if (_dashDir == Vector3.zero)
//             {
//                 _dashDir = _movementInput.FacingLeft ? Vector3.left : Vector3.right;
//             }
//
//             _dashRing.up = _dashDir;
//             // _dashParticles.Play();
//             IsDashing = true;
//             _hasDashed = true;
//             _timeStartedDash = Time.time;
//             _rigidbody.useGravity = false;
//             // _dashVisual.Play();
//             // PlayRandomClip(_dashClips);
//             OnStartDashing?.Invoke();
//         }
//
//         if (IsDashing)
//         {
//             _rigidbody.velocity = _dashDir * _dashSpeed;
//
//             if (Time.time >= _timeStartedDash + _dashLength)
//             {
//                 // _dashParticles.Stop();
//                 IsDashing = false;
//
//                 // Clamp the velocity so they don't keep shooting off
//                 _rigidbody.velocity = new Vector3(_rigidbody.velocity.x,
//                     _rigidbody.velocity.y > 3 ? 3 : _rigidbody.velocity.y);
//                 _rigidbody.useGravity = true;
//
//                 if (_isGrounded.Value)
//                 {
//                     _hasDashed = false;
//                 }
//
//                 // _dashVisual.Stop();
//                 OnStopDashing?.Invoke();
//             }
//         }
//     }
// }