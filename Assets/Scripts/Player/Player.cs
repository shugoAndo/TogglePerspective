using UnityEngine;
using UnityEngine.InputSystem;

namespace TogglePerspective
{
    /// <summary>�v���C���[�̓��͂��w��</summary>
    public class Player : MonoBehaviour
    {
        Vector2 moveInput = Vector2.zero;

        PlayerInput playerInput;
        MoveBehaviour moveBehaviour;

        // �X���[�v��ԂȂ�true�A�����łȂ��Ȃ�false�B
        public bool isSleeping { get; private set; }

        private void Awake()
        {
            // �}�E�X�J�[�\���̔�\���B
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
                // ���[�U�[���͂̑傫�����v�Z[0, 1]�B
                var speed = moveInput.magnitude;

                // ���[�U�[����̓��͂�3�������B
                var inputDirection = new Vector3(moveInput.x, 0, moveInput.y);

                // �ړ����͂�����ꍇ�B
                if (moveInput != Vector2.zero)
                {
                    // �J�����̕��ʊp����ɂ��ē��͂��ꂽ���ʊp(Degree)���v�Z�B
                    // �v�L�[�������΁A�J�����������Ă�������ɐi�ފԊu�B
                }
                
            }
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