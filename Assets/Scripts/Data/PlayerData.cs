using UnityEngine;

namespace TogglePerspective
{
    [AddComponentMenu("�y�v���C���[�̃p�����[�^�[�z")]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Player")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField, Tooltip("�������x�̎w��")]
        public int walkSpeed;

        [SerializeField, Tooltip("���鑬�x�̎w��")]
        public int runSpeed;

        [SerializeField, Tooltip("�W�����v�͂̎w��")]
        public int jumpPower;
    }
}
