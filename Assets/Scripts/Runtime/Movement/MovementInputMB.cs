using ClipperLib;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class MovementInputMB : CachedMB
{
    [Header(HeaderTitles.Output)]
    [SerializeField]
    private IntReference _rawX;

    [SerializeField]
    private IntReference _rawY;

    [SerializeField]
    private FloatReference _x;

    [SerializeField]
    private FloatReference _y;

    public bool FacingLeft { get; private set; }

    public int RawX
    {
        get => _rawX.Value;
        private set => _rawX.Value = value;
    }

    public int RawY
    {
        get => _rawY.Value;
        private set => _rawY.Value = value;
    }

    public float X
    {
        get => _x.Value;
        private set => _x.Value = value;
    }

    public float Y
    {
        get => _y.Value;
        private set => _y.Value = value;
    }

    private void GatherInputs()
    {
        RawX = (int) Input.GetAxisRaw("Horizontal");
        RawY = (int) Input.GetAxisRaw("Vertical");
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        // _anim.SetInteger("RawY", _inputs.RawY);

        FacingLeft = RawX != 1 && (RawX == -1 || FacingLeft);

        // if (!_grabbing)
        // {
        //     SetFacingDirection(FacingLeft); // Don't turn while grabbing the wall
        // }
    }

    // private void SetFacingDirection(bool left)
    // {
    //     _anim.transform.rotation = left ? Quaternion.Euler(0, -90, 0) : Quaternion.Euler(0, 90, 0);
    // }
}