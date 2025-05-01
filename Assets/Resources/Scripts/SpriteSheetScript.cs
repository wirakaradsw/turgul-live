using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetScript : MonoBehaviour
{
    public bool autoGetSprites = true;
    public GameObject[] sprites;
    public float animSpeed1 = 1f;
    public float animSpeed2 = 1f;
    private float _animCount = 0;
    private bool _isAnimCount1 = true;
    private int _spriteOrder = 0;

    private void Awake()
    {
        if (autoGetSprites)
        {
            sprites = new GameObject[gameObject.transform.childCount];
            for (int i = 0; i < sprites.Length; i++)
                sprites[i] = gameObject.transform.GetChild(i).gameObject;
        }

        ResetAnim();
    }

    private void Update()
    {
        // ------------------------------------------------------------------
        // Cycle the game object animation
        // ------------------------------------------------------------------
        _animCount = _animCount - Time.deltaTime;

        if (_animCount <= 0)
        {
            if (_isAnimCount1)
            {
                _isAnimCount1 = false;
                _animCount = animSpeed2;
            }
            else
            {
                _isAnimCount1 = true;
                _animCount = animSpeed1;
            }
            
            _spriteOrder++;

            if (_spriteOrder == sprites.Length)
                _spriteOrder = 0;

            for (int i = 0; i < sprites.Length; i++)
                sprites[i].SetActive(false);

            sprites[_spriteOrder].SetActive(true);
        }
    }

    // ------------------------------------------------------------------
    // Reset/play from beginning of the game object animation
    // ------------------------------------------------------------------
    public void ResetAnim()
    {
        for (int i = 0; i < sprites.Length; i++)
            sprites[i].SetActive(false);

        sprites[0].SetActive(true);
        _spriteOrder = 0;
        _animCount = animSpeed1;
    }
}
