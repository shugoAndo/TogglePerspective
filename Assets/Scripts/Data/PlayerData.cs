using UnityEngine;

namespace TogglePerspective
{
    [AddComponentMenu("【プレイヤーのパラメーター】")]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Player")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField, Tooltip("歩く速度の指定")]
        public int walkSpeed;

        [SerializeField, Tooltip("走る速度の指定")]
        public int runSpeed;

        [SerializeField, Tooltip("ジャンプ力の指定")]
        public int jumpPower;
    }
}
