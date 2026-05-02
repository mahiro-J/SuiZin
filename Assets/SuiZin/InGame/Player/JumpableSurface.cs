using UnityEngine;

namespace SuiZin.InGame
{
    /// <summary>
    /// 地面などプレイヤーが立てるオブジェクトに付与する。<see cref="isJumpable"/> が false のときはジャンプできない。
    /// 未付与のオブジェクトは従来どおりジャンプ可能（Ground レイヤーかつレイキャストがヒットすれば可）。
    /// </summary>
    public class JumpableSurface : MonoBehaviour
    {
        public bool isJumpable = true;
    }
}
