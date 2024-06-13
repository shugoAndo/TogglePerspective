using UnityEngine;
using UnityEngine.InputSystem;

namespace TogglePerspective
{
    /// <summary>�v���C���[�̓��͂��w��</summary>
    public class Player : MonoBehaviour
    {
        // ���[�U�[����Move�A�N�V�����̓��͒l�B
        Vector2 moveInput = Vector2.zero;

        // ���̃L�����N�^�[�̖ڕW���ʊp�iworld��z��������0�j�B
        float targetHeading = 0;

        PlayerInput playerInput;
        MoveBehaviour moveBehaviour;

        // �X���[�v��ԂȂ�true�A�����łȂ��Ȃ�false�B
        public bool isSleeping { get; private set; }

        private void Awake()
        {
            // �}�E�X�J�[�\���̔�\���B
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
                // ���[�U�[���͂̑傫�����v�Z[0, 1]�B
                var speed = moveInput.magnitude;

                // ���[�U�[����̓��͂�3�������B
                var inputDirection = new Vector3(moveInput.x, 0, moveInput.y);

                // �ړ����͂�����ꍇ�B
                if (moveInput != Vector2.zero)
                {
                    // �J�����̕��ʊp����ɂ��ē��͂��ꂽ���ʊp(Degree)���v�Z�B
                    // �v�L�[�������΁A�J�����������Ă�������ɐi�ފԊu�B
                    targetHeading = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
                    targetHeading += Camera.main.transform.eulerAngles.y;
                }
                // �J�����̐��ʂ̊�Ɉړ��B
                var targetDirection = Quaternion.Euler(0.0f, targetHeading, 0.0f) * Vector3.forward;
                moveBehaviour.Move(targetDirection * speed);
            }
        }

        /// <summary>�������͏���</summary>
        /// <param name="context"></param>
        public void OnMove(InputAction.CallbackContext context)
        {
            if (!isSleeping)
            {
                moveInput = context.ReadValue<Vector2>();
            }
        }

        /// <summary>������͏���</summary>
        /// <param name="context"></param>
        public void OnRun(InputAction.CallbackContext context)
        {

        }

        /// <summary>�W�����v���͏���</summary>
        /// <param name="context"></param>
        public void OnJump(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>�A�N�V�������͏���</summary>
        /// <param name="context"></param>
        public void OnAction(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>�|�[�Y���͏���</summary>
        /// <param name="context"></param>
        public void OnPause(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>�v���C���[���X���[�v��Ԃɂ���</summary>
        public void Sleep()
        {
            isSleeping = true;
        }

        /// <summary>�v���C���[���N����Ԃɂ���</summary>
        public void WakeUp()
        {
            isSleeping = false;
        }
    }
}