// using System;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// /// <summary>
// /// Hey developer!
// /// If you have any questions, come chat with me on my Discord: https://discord.gg/GqeHHnhHpz
// /// If you enjoy the controller, make sure you give the video a thumbs up: https://youtu.be/rJECT58CQHs
// /// Have fun!
// ///
// /// Love,
// /// Tarodev
// /// </summary>
// public class MovementMB : MonoBehaviour
// {
//     [SerializeField]
//     private Rigidbody _rb;
//
//     [SerializeField]
//     private Animator _anim;
//
//     private void Update()
//     {
//         HandleWalking();
//
//         HandleJumping();
//
//         HandleWallSlide();
//
//         HandleWallGrab();
//     }
//
//     #region Walking
//
//     [Header("Walking")]
//     [SerializeField]
//     private float _walkSpeed = 4;
//
//     [SerializeField]
//     private float _acceleration = 2;
//
//     [SerializeField]
//     private float _currentMovementLerpSpeed = 100;
//
//     private void HandleWalking()
//     {
//         // Slowly release control after wall jump
//         _currentMovementLerpSpeed =
//             Mathf.MoveTowards(_currentMovementLerpSpeed, 100, _wallJumpMovementLerp * Time.deltaTime);
//
//         if (_dashing) return;
//         // This can be done using just X & Y input as they lerp to max values, but this gives greater control over velocity acceleration
//         var acceleration = IsGrounded ? _acceleration : _acceleration * 0.5f;
//
//         if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             if (_rb.velocity.x > 0) _inputs.X = 0; // Immediate stop and turn. Just feels better
//             _inputs.X = Mathf.MoveTowards(_inputs.X, -1, acceleration * Time.deltaTime);
//         }
//         else if (Input.GetKey(KeyCode.RightArrow))
//         {
//             if (_rb.velocity.x < 0) _inputs.X = 0;
//             _inputs.X = Mathf.MoveTowards(_inputs.X, 1, acceleration * Time.deltaTime);
//         }
//         else
//         {
//             _inputs.X = Mathf.MoveTowards(_inputs.X, 0, acceleration * 2 * Time.deltaTime);
//         }
//
//         var idealVel = new Vector3(_inputs.X * _walkSpeed, _rb.velocity.y);
//         // _currentMovementLerpSpeed should be set to something crazy high to be effectively instant. But slowed down after a wall jump and slowly released
//         _rb.velocity = Vector3.MoveTowards(_rb.velocity, idealVel, _currentMovementLerpSpeed * Time.deltaTime);
//
//         _anim.SetBool("Walking", _inputs.RawX != 0 && IsGrounded);
//     }
//
//     #endregion
//
//     #region Jumping
//
//
//     #endregion
//
//     #region Wall Slide
//
//     [Header("Wall Slide")]
//     [SerializeField]
//     private ParticleSystem _wallSlideParticles;
//
//     [SerializeField]
//     private float _slideSpeed = 1;
//
//     private bool _wallSliding;
//
//     private void HandleWallSlide()
//     {
//         var sliding = _pushingLeftWall || _pushingRightWall;
//
//         if (sliding && !_wallSliding)
//         {
//             transform.SetParent(_pushingLeftWall ? _leftWall[0].transform : _rightWall[0].transform);
//             _wallSliding = true;
//             _wallSlideParticles.transform.position = transform.position +
//                                                      new Vector3(
//                                                          _pushingLeftWall ? -_wallCheckOffset : _wallCheckOffset, 0);
//             _wallSlideParticles.Play();
//
//             // Don't add sliding until actually falling or it'll prevent jumping against a wall
//             if (_rb.velocity.y < 0) _rb.velocity = new Vector3(0, -_slideSpeed);
//         }
//         else if (!sliding && _wallSliding && !_grabbing)
//         {
//             transform.SetParent(null);
//             _wallSliding = false;
//             _wallSlideParticles.Stop();
//         }
//     }
//
//     private void DrawWallSlideGizmos()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position + new Vector3(-_wallCheckOffset, 0), _wallCheckRadius);
//         Gizmos.DrawWireSphere(transform.position + new Vector3(_wallCheckOffset, 0), _wallCheckRadius);
//     }
//
//     #endregion
//
//     #region Wall Grab
//     //
//     // [Header("Wall Grab")]
//     // [SerializeField]
//     // private ParticleSystem _wallGrabParticles;
//     //
//     // private bool _grabbing;
//     //
//     // private void HandleWallGrab()
//     // {
//     //     // I added wallJumpLock but I honestly can't remember why and I'm too scared to remove it...
//     //     var grabbing = (_isAgainstLeftWall || _isAgainstRightWall) && Input.GetKey(KeyCode.Z) &&
//     //                    Time.time > _timeLastWallJumped + _wallJumpLock;
//     //
//     //     _rb.useGravity = !_grabbing;
//     //     if (grabbing && !_grabbing)
//     //     {
//     //         _grabbing = true;
//     //         _wallGrabParticles.transform.position = transform.position +
//     //                                                 new Vector3(_pushingLeftWall ? -_wallCheckOffset : _wallCheckOffset,
//     //                                                     0);
//     //         _wallGrabParticles.Play();
//     //         SetFacingDirection(_isAgainstLeftWall);
//     //     }
//     //     else if (!grabbing && _grabbing)
//     //     {
//     //         _grabbing = false;
//     //         _wallGrabParticles.Stop();
//     //         Debug.Log("stopped");
//     //     }
//     //
//     //     if (_grabbing) _rb.velocity = new Vector3(0, _inputs.RawY * _slideSpeed * (_inputs.RawY < 0 ? 1 : 0.8f));
//     //
//     //     _anim.SetBool("Climbing", _wallSliding || _grabbing);
//     // }
//     //
//     #endregion
//
//     #region Impacts
//
//     [Header("Collisions")]
//     [SerializeField]
//     private ParticleSystem _impactParticles;
//
//     [SerializeField]
//     private GameObject _deathExplosion;
//
//     [SerializeField]
//     private float _minImpactForce = 2;
//
//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.relativeVelocity.magnitude > _minImpactForce && IsGrounded) _impactParticles.Play();
//     }
//
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Death"))
//         {
//             Instantiate(_deathExplosion, transform.position, Quaternion.identity);
//             Destroy(gameObject);
//         }
//
//         _hasDashed = false;
//     }
//
//     #endregion
//
//     // #region Audio
//     //
//     // [Header("Audio")]
//     // [SerializeField]
//     // private AudioSource _source;
//     //
//     // [SerializeField]
//     // private AudioClip[] _landClips;
//     //
//     // [SerializeField]
//     // private AudioClip[] _dashClips;
//     //
//     // private void PlayRandomClip(AudioClip[] clips)
//     // {
//     //     _source.PlayOneShot(clips[Random.Range(0, clips.Length)], 0.2f);
//     // }
//     //
//     // #endregion
// }