using UnityEngine;
using UnityEngine.InputSystem;

namespace TogglePerspective
{
    /// <summary>プレイヤーの入力を指定</summary>
    public class Player : MonoBehaviour
    {
        Vector2 moveInput = Vector2.zero;

        PlayerInput playerInput;
        MoveBehaviour moveBehaviour;

        // スリープ状態ならtrue、そうでないならfalse。
        public bool isSleeping { get; private set; }

        private void Awake()
        {
            // マウスカーソルの非表示。
            Cursor.visible = false;
            Sleep();
        }

        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveBehaviour = GetComponent<MoveBehaviour>();
        }

        void Update()
        {
            if(isSleeping)
            {
                // ユーザー入力の大きさを計算[0, 1]。
                var speed = moveInput.magnitude;

                // ユーザーからの入力を3次元化。
                var inputDirection = new Vector3(moveInput.x, 0, moveInput.y);

                // 移動入力がある場合。
                if (moveInput != Vector2.zero)
                {
                    // カメラの方位角を基準にして入力された方位角(Degree)を計算。
                    // Ｗキーを押せば、カメラが向いている方向に進む間隔。
                }
                
            }
        }

        /// <summary>プレイヤーをスリープ状態にする</summary>
        public void Sleep()
        {
            isSleeping = true;
        }

        /// <summary>プレイヤーを起動状態にする</summary>
        public void WakeUp()
        {
            isSleeping = false;
        }
    }
}