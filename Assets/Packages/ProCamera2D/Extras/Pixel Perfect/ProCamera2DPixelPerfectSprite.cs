using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
    [ExecuteInEditMode]
    public class ProCamera2DPixelPerfectSprite : BasePC2D
    {
        public bool IsAMovingObject;
        public bool IsAChildSprite;
        public Vector2 LocalPosition;

        [Range(-8, 32)]
        public int SpriteScale = 0;

        Sprite _sprite;

        #if PC2D_TK2D_SUPPORT
        tk2dSprite _spriteTk2d;
        #endif

        ProCamera2DPixelPerfect _pixelPerfectPlugin;

        [SerializeField]
        Vector3 _initialScale = Vector3.one;
        int _prevSpriteScale;

        protected override void Start()
        {
            base.Start();

            GetPixelPerfectPlugin();

            GetSprite();

            SetAsPixelPerfect();
        }
        
        override protected void OnPostMoveUpdate(float deltaTime)
        {
            Step();
        }

        #if UNITY_EDITOR
        void LateUpdate()
        {
            if(!Application.isPlaying && !IsAMovingObject && _pixelPerfectPlugin.enabled)
                SetAsPixelPerfect();
                
            if(!Application.isPlaying)
                Step();
        }
        #endif
        
        void Step()
        {
            if (!_pixelPerfectPlugin.enabled)
                return;

            if (IsAMovingObject)
                SetAsPixelPerfect();

            _prevSpriteScale = SpriteScale;
        }

        void GetPixelPerfectPlugin()
        {
            _pixelPerfectPlugin = ProCamera2D.GetComponent<ProCamera2DPixelPerfect>();
        }

        void GetSprite()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                _sprite = spriteRenderer.sprite;

            #if PC2D_TK2D_SUPPORT
            if (_sprite == null)
                _spriteTk2d = GetComponent<tk2dSprite>();
            #endif
        }

        public void SetAsPixelPerfect()
        {
            #if UNITY_EDITOR
            if (Vector3H == null)
                base.Start();

            if (_sprite == null)
                GetSprite();

            if (_pixelPerfectPlugin == null)
                GetPixelPerfectPlugin();

            if (Vector3H == null || _sprite == null || _pixelPerfectPlugin == null)
                return;
            #endif

            // Reset position
            if (IsAChildSprite)
                _transform.localPosition = VectorHVD(
                    Utils.AlignToGrid(LocalPosition.x, _pixelPerfectPlugin.PixelStep), 
                    Utils.AlignToGrid(LocalPosition.y, _pixelPerfectPlugin.PixelStep), 
                    Vector3D(_transform.localPosition));

            // Position
            _transform.position = VectorHVD(
                Utils.AlignToGrid(Vector3H(_transform.position), _pixelPerfectPlugin.PixelStep), 
                Utils.AlignToGrid(Vector3V(_transform.position), _pixelPerfectPlugin.PixelStep),
                Vector3D(_transform.position));

            // Scale
            if (SpriteScale == 0)
            {
                //The user was at 0 scale the last update, so save the current scale
                if (_prevSpriteScale == 0)
                    _initialScale = _transform.localScale;
                //The user just changed the scale to 0, so restore the original scale
                else
                    _transform.localScale = _initialScale;
            }
            else
            {
                var adjustedSpriteScale = SpriteScale < 0 ? 1f / (float)SpriteScale * -1f : SpriteScale;
                var scale = 1f;

                #if PC2D_TK2D_SUPPORT
                if (_spriteTk2d != null)
                {
                    scale = _pixelPerfectPlugin.Tk2DPixelsPerMeter * adjustedSpriteScale * (1 / _pixelPerfectPlugin.PixelsPerUnit);
                }
                else
                {
                #endif

                    scale = _sprite.pixelsPerUnit * adjustedSpriteScale * (1 / _pixelPerfectPlugin.PixelsPerUnit);

                    #if PC2D_TK2D_SUPPORT
                }
                    #endif

                _transform.localScale = new Vector3(
                    Mathf.Sign(_transform.localScale.x) * scale, 
                    Mathf.Sign(_transform.localScale.y) * scale, 
                    _transform.localScale.z);
            }
        }
    }
}