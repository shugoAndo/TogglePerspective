using UnityEngine;
using UnityEngine.InputSystem;

namespace TogglePerspective
{
    /// <summary>プレイヤーの入力を指定</summary>
    public class Player : MonoBehaviour
    {
        // ユーザーからMoveアクションの入力値。
        Vector2 moveInput = Vector2.zero;

        // このキャラクターの目標方位角（worldのz軸方向が0）。
        float targetHeading = 0;

        PlayerInput playerInput;
        MoveBehaviour moveBehaviour;

        // スリープ状態ならtrue、そうでないならfalse。
        public bool isSleeping { get; private set; }

        private void Awake()
        {
            // マウスカーソルの非表示。
            Cursor.visible = false;
        }

        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveBehaviour = GetComponent<MoveBehaviour>();
        }

        void Update()
        {
            if (!isSleeping)
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
                    targetHeading = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
                    targetHeading += Camera.main.transform.eulerAngles.y;
                }
                // カメラの正面の基準に移動。
                var targetDirection = Quaternion.Euler(0.0f, targetHeading, 0.0f) * Vector3.forward;
                moveBehaviour.Move(targetDirection * speed);
            }
        }

        /// <summary>歩き入力処理</summary>
        /// <param name="context"></param>
        public void OnMove(InputAction.CallbackContext context)
        {
            if (!isSleeping)
            {
                moveInput = context.ReadValue<Vector2>();
            }
        }

        /// <summary>走り入力処理</summary>
        /// <param name="context"></param>
        public void OnRun(InputAction.CallbackContext context)
        {

        }

        /// <summary>ジャンプ入力処理</summary>
        /// <param name="context"></param>
        public void OnJump(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>アクション入力処理</summary>
        /// <param name="context"></param>
        public void OnAction(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>ポーズ入力処理</summary>
        /// <param name="context"></param>
        public void OnPause(InputAction.CallbackContext context)
        {
            
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