using Unity.VisualScripting;
using UnityEngine;

namespace TogglePerspective
{
    /// <summary>�v���C���[�̓�����Ǘ�</summary>
    public class MoveBehaviour : MonoBehaviour
    {
        [SerializeField, Tooltip("PlayerData���w��")]
        public PlayerData playerData;

        [SerializeField, Tooltip("AsyncData���w��")]
        public AsyncData asyncData;

        new Rigidbody rigidbody;

        // �v���C���[�̏�Ԃ�\���܂��B
        enum PlayerState
        {
            // �ҋ@��ԁB
            Stop,
            // ������ԁB
            Walk,
            // ������
            Run,
            // �W�����v�ҋ@��ԁB
            JumpReady,
            // �W�����v��ԁB
            Jumping,
            // �A�N�V������ԁB�i�j��A�ݒu�A�g�p�j
            Action,
        }

        // ���݂̃v���C���[��ԁB
        PlayerState currentState = PlayerState.Stop;

        private void Awake()
        {
            // �R���|�[�l���g���Q�Ƃ��Ă����ϐ��B
            rigidbody = GetComponent<Rigidbody>();
        }

        #region ---Set(  )State----------
        // StopState�ɑJ�ڂ����܂��B
        void SetStopState()
        {
            currentState = PlayerState.Stop;
        }

        // WalkState�ɑJ�ڂ����܂��B
        void SetWalkState()
        {
            currentState = PlayerState.Walk;
        }

        // RunState�ɑJ�ڂ����܂��B
        void SetRunState()
        {
            currentState = PlayerState.Run;
        }

        // JumpReadyState�ɑJ�ڂ����܂��B
        void SetJumpReadyState()
        {
            currentState = PlayerState.JumpReady;
        }

        // JumpingState�ɑJ�ڂ����܂��B
        void SetJumpindState()
        {
            currentState = PlayerState.Jumping;
        }

        // Actiontate�ɑJ�ڂ����܂��B
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
        /// <summary>StopState��Ԓ��̏���</summary>
        void UpdateForStopState()
        {

        }

        /// <summary>WalkState��Ԓ��̏���</summary>
        void UpdateForWalkState()
        {

        }

        /// <summary>RunState��Ԓ��̏���</summary>
        void UpdateForRunState()
        {

        }

        /// <summary>JumpReadyState��Ԓ��̏���</summary>
        void UpdateForJumpReadyState()
        {

        }

        /// <summary>JumpingState��Ԓ��̏���</summary>
        void UpdateForJumpingState()
        {

        }

        /// <summary>ActionState��Ԓ��̏���</summary>
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

                // �v���C���[�̉�]�B
                var rotation = Quaternion.LookRotation(moveInput);
                Debug.Log(rotation);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerData.rotateSpeed * Time.deltaTime);
            }
            else
            {
                SetStopState();
            }
            // �v���C���[�̈ړ��B
            var velocity = moveInput * playerData.walkSpeed;
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        }
    }
}