using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplitSectionInHalf : MonoBehaviour
{
    [Tooltip("X=Left Y=Right")]
    public Vector2 Padding;
    public TextMeshProUGUI left;
    public TextMeshProUGUI right;

    IEnumerator SetWidth()
    {
        yield return new WaitForFixedUpdate();
        float hori = GetComponent<RectTransform>().rect.width;

        left.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hori / 2);
        right.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hori / 2);

        left.rectTransform.SetRight(-(hori / 2) + Padding.x);
        right.rectTransform.SetLeft(-(hori / 2) + Padding.y);
    }

    void FixedUpdate()
    {
        StartCoroutine(SetWidth());
    }
}
