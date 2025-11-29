using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // プレイヤーをドラッグ＆ドロップ
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -5); // プレイヤーからの距離
    [SerializeField] private float smoothSpeed = 5f; // 追従の滑らかさ（大きいほど速い）
    private Transform _myTransform;

    private void Awake()
    {
        _myTransform = transform;
    }

    // カメラの追従は LateUpdate で書くのが鉄則！
    // (UpdateやFixedUpdateで動いたプレイヤーの「移動後の位置」に合わせるため)
    private void LateUpdate()
    {
        if (target == null) return;

        // 1. 目標位置の計算
        // target.TransformPoint(offset) を使うと
        // 「プレイヤーの向きに合わせて回転した状態」での後ろの位置を計算してくれます
        Vector3 desiredPosition = target.TransformPoint(offset);

        // // 2. 位置の移動（Lerpを使って滑らかに移動）
        _myTransform.position = Vector3.Lerp(_myTransform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 3. 回転の制御（常にプレイヤーの方を向く）
        // カメラの位置が滑らかに動くので、LookAtを使うだけで「ふわっとした回転」になります
        var lookTarget = target.position + Vector3.up * 1.5f; // 足元ではなく少し上を見る
        _myTransform.LookAt(lookTarget);
    }
}
