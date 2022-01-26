// using niscolas.UnityUtils.Core;
// using UnityAtoms.BaseAtoms;
// using UnityEngine;
//
// public class JumperMB : CachedMB
// {
//     [SerializeField]
//     private DasherMB _dasher;
//
//     [SerializeField]
//     private SurfaceDetectorMB _surfaceDetector;
//     
//     [Header("Settings")]
//     [SerializeField]
//     private FloatReference _jumpForce = new FloatReference(15);
//
//     [SerializeField]
//     private FloatReference _fallMultiplier = new FloatReference(7);
//
//     [SerializeField]
//     private FloatReference _jumpVelocityFalloff = new FloatReference(8);
//
//     // [SerializeField]
//     // private ParticleSystem _jumpParticles;
//
//     [SerializeField]
//     private Transform _jumpLaunchPoof;
//
//     [SerializeField]
//     private FloatReference _wallJumpLock = new FloatReference(0.25f);
//
//     [SerializeField]
//     private FloatReference _wallJumpMovementLerp = new FloatReference(5);
//
//     [SerializeField]
//     private FloatReference _coyoteTime = new FloatReference(0.2f);
//
//     [SerializeField]
//     private bool _enableDoubleJump = true;
//
//     private float _timeLeftGrounded = -10;
//     private float _timeLastWallJumped;
//     private bool _hasJumped;
//     private bool _hasDoubleJumped;
//
//     private void HandleJumping()
//     {
//         if (_dasher.IsDashing)
//         {
//             return;
//         }
//
//         if (Input.GetKeyDown(KeyCode.C))
//         {
//             if (
//                 // _grabbing || 
//                 !_surfaceDetector.IsGrounded && 
//                 (_surfaceDetector.IsAgainstLeftWall || _surfaceDetector.IsAgainstRightWall))
//             {
//                 _timeLastWallJumped = Time.time;
//                 _currentMovementLerpSpeed = _wallJumpMovementLerp;
//                 ExecuteJump(new Vector2(_isAgainstLeftWall ? _jumpForce : -_jumpForce, _jumpForce)); // Wall jump
//             }
//             else if (IsGrounded || Time.time < _timeLeftGrounded + _coyoteTime ||
//                      _enableDoubleJump && !_hasDoubleJumped)
//             {
//                 if (!_hasJumped || _hasJumped && !_hasDoubleJumped)
//                     ExecuteJump(new Vector2(_rb.velocity.x, _jumpForce), _hasJumped); // Ground jump
//             }
//         }
//
//         void ExecuteJump(Vector3 dir, bool doubleJump = false)
//         {
//             _rb.velocity = dir;
//             _jumpLaunchPoof.up = _rb.velocity;
//             _jumpParticles.Play();
//             _anim.SetTrigger(doubleJump ? "DoubleJump" : "Jump");
//             _hasDoubleJumped = doubleJump;
//             _hasJumped = true;
//         }
//
//         // Fall faster and allow small jumps. _jumpVelocityFalloff is the point at which we start adding extra gravity. Using 0 causes floating
//         if (_rb.velocity.y < _jumpVelocityFalloff || _rb.velocity.y > 0 && !Input.GetKey(KeyCode.C))
//             _rb.velocity += _fallMultiplier * Physics.gravity.y * Vector3.up * Time.deltaTime;
//     }
// }