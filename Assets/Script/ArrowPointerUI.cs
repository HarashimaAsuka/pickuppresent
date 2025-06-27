using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowPointerUI : MonoBehaviour
{
    public Transform target;
    public RectTransform canvasRectTransform;
    public RectTransform arrowRectTransform;
    public Vector2 arrowPosition;

    void Update()
    {
        if (target != null)
        {
            // ターゲットのスクリーン座標を計算
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // 矢印の位置をキャンバスの中央に固定
            // arrowRectTransform.anchoredPosition = Vector2.zero;
            arrowRectTransform.anchoredPosition = arrowPosition;

            // 矢印の回転を設定
            Vector3 direction = target.position - Camera.main.transform.position;
            direction.z = 0f; // 2DなのでZ軸は無視
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrowRectTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
