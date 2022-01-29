using System.Linq;
using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelEditorInputMB : CachedMB
{
    [SerializeField]
    private LevelEditorMB _levelEditor;

    [Header("Inputs")]
    [SerializeField]
    private Vector2Reference _mousePosition;

    [SerializeField]
    private BoolEventReference _leftButtonClickedEvent;

    [SerializeField]
    private BoolEventReference _rightButtonClickedEvent;

    [Header("Settings")]
    [SerializeField]
    private BlockMB[] _possibleBlocks;

    [Header(HeaderTitles.Debug)]
    [SerializeField]
    private BlockMB _selectedBlock;

    private Camera _camera;
    private bool _isHoldingLeftClick;
    private bool _isHoldingRightClick;

    private void Start()
    {
        _camera = Camera.main;
        _leftButtonClickedEvent.GetEvent<BoolEvent>().Register(OnMouseLeftClickStateChanged);
        _rightButtonClickedEvent.GetEvent<BoolEvent>().Register(OnMouseRightClickStateChanged);
        SetupKeyboardEvents();
    }

    private void Update()
    {
        if (_isHoldingLeftClick)
        {
            PlaceBlock();
        }

        if (_isHoldingRightClick)
        {
            EraseHoveredBlock();
        }
    }

    private void EraseHoveredBlock()
    {
        _levelEditor.EraseTopMostLayer(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(_mousePosition.Value);
    }

    private void PlaceBlock()
    {
        if (!_selectedBlock)
        {
            SelectFirstBlock();

            if (!_selectedBlock)
            {
                return;
            }
        }

        _levelEditor.Place(_selectedBlock.LayerNumber, _selectedBlock, GetMousePosition());
    }

    private void OnMouseLeftClickStateChanged(bool value)
    {
        _isHoldingLeftClick = value;
    }

    private void OnMouseRightClickStateChanged(bool value)
    {
        _isHoldingRightClick = value;
    }

    private void SelectFirstBlock()
    {
        _selectedBlock = _possibleBlocks.First(x => x);
    }

    private void SetupKeyboardEvents()
    {
        for (int i = 1; i <= 9; i++)
        {
            InputAction inputAction = new InputAction(binding: $"<Keyboard>/{i}");

            int innerIndex = i;
            inputAction.performed += context => SelectBlock(innerIndex - 1);

            inputAction.Enable();
        }
    }

    private void SelectBlock(int blockIndex)
    {
        if (blockIndex < 0 || blockIndex >= _possibleBlocks.Length)
        {
            return;
        }

        BlockMB block = _possibleBlocks[blockIndex];

        if (!block)
        {
            return;
        }

        _selectedBlock = block;
    }
}