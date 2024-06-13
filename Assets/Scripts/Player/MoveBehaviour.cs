using Unity.VisualScripting;
using UnityEngine;

namespace TogglePerspective
{
    /// <summary>プレイヤーの動作を管理</summary>
    public class MoveBehaviour : MonoBehaviour
    {
        [SerializeField, Tooltip("PlayerDataを指定")]
        public PlayerData playerData;

        [SerializeField, Tooltip("AsyncDataを指定")]
        public AsyncData asyncData;

        new Rigidbody rigidbody;

        // プレイヤーの状態を表します。
        enum PlayerState
        {
            // 待機状態。
            Stop,
            // 歩き状態。
            Walk,
            // 走り状態
            Run,
            // ジャンプ待機状態。
            JumpReady,
            // ジャンプ状態。
            Jumping,
            // アクション状態。（破壊、設置、使用）
            Action,
        }

        // 現在のプレイヤー状態。
        PlayerState currentState = PlayerState.Stop;

        private void Awake()
        {
            // コンポーネントを参照しておく変数。
            rigidbody = GetComponent<Rigidbody>();
        }

        #region ---Set(  )State----------
        // StopStateに遷移させます。
        void SetStopState()
        {
            currentState = PlayerState.Stop;
        }

        // WalkStateに遷移させます。
        void SetWalkState()
        {
            currentState = PlayerState.Walk;
        }

        // RunStateに遷移させます。
        void SetRunState()
        {
            currentState = PlayerState.Run;
        }

        // JumpReadyStateに遷移させます。
        void SetJumpReadyState()
        {
            currentState = PlayerState.JumpReady;
        }

        // JumpingStateに遷移させます。
        void SetJumpindState()
        {
            currentState = PlayerState.Jumping;
        }

        // Actiontateに遷移させます。
        void SetActionState()
        {
            currentState = PlayerState.Action;
        }
        #endregion

        void Start()
        {
            SetStopState();
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case PlayerState.Stop:
                    UpdateForStopState();
                    break;
                case PlayerState.Walk:
                    UpdateForWalkState();
                    break;
                case PlayerState.Run:
                    UpdateForRunState();
                    break;
                case PlayerState.JumpReady:
                    UpdateForJumpReadyState();
                    break;
                case PlayerState.Jumping:
                    UpdateForJumpingState();
                    break;
                case PlayerState.Action:
                    UpdateForActionState();
                    break;
            }
        }

        #region ---UpdateFor(  )State----------
        /// <summary>StopState状態中の処理</summary>
        void UpdateForStopState()
        {

        }

        /// <summary>WalkState状態中の処理</summary>
        void UpdateForWalkState()
        {

        }

        /// <summary>RunState状態中の処理</summary>
        void UpdateForRunState()
        {

        }

        /// <summary>JumpReadyState状態中の処理</summary>
        void UpdateForJumpReadyState()
        {

        }

        /// <summary>JumpingState状態中の処理</summary>
        void UpdateForJumpingState()
        {

        }

        /// <summary>ActionState状態中の処理</summary>
        void UpdateForActionState()
        {

        }
        #endregion

        public void Move(Vector3 moveInput)
        {
            if(moveInput != Vector3.zero)
            {
                SetWalkState();

                var input = Mathf.Max(Mathf.Abs(moveInput.x), Mathf.Abs(moveInput.z));

                // プレイヤーの回転。
                var rotation = Quaternion.LookRotation(moveInput);
                Debug.Log(rotation);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerData.rotateSpeed * Time.deltaTime);
            }
            else
            {
                SetStopState();
            }
            // プレイヤーの移動。
            var velocity = moveInput * playerData.walkSpeed;
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        }
    }
}