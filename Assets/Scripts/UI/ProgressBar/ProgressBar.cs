using Exsersewo.Nydaliv.Extensions;
using System.Collections;
using UnityEngine;

namespace Exsersewo.UI.ProgressBar
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        RectTransform ValueSlider;
        public ProgressBarType FillType;

        [Tooltip("X=Left Y=Right")]
        public Vector2 Padding;

        [SerializeField]
        ProgressTransitionType Transition;

        [SerializeField]
        float TransitionTime = .5f;

        [SerializeField]
        float previousValue;

        RectTransform RectTransform;

        void Start()
        {
            RectTransform = GetComponent<RectTransform>();
            previousValue = ValueSlider.rect.width;
        }

        IEnumerator SetWidth(ulong value, ulong maxValue)
        {
            float hori = RectTransform.rect.width;

            var width = ((float)value).Remap(0, maxValue, 0, hori-(Padding.x+Padding.y));

            switch (Transition)
            {
                case ProgressTransitionType.Lerp:
                case ProgressTransitionType.SmoothStep:
                    {
                        float TimeLerped = 0f;

                        while (TimeLerped <= TransitionTime)
                        {
                            float lerpVal = 0;

                            switch (Transition)
                            {
                                case ProgressTransitionType.SmoothStep:
                                    lerpVal = Mathf.SmoothStep(previousValue, width, TimeLerped / TransitionTime);
                                    break;
                                case ProgressTransitionType.Lerp:
                                    lerpVal = Mathf.Lerp(previousValue, width, TimeLerped / TransitionTime);
                                    break;
                            }

                            SetSliderPosition(lerpVal);

                            TimeLerped += Time.deltaTime;

                            yield return null;
                        }
                    }
                    break;
                case ProgressTransitionType.Instant:
                default:
                    {
                        SetSliderPosition(width);
                    }
                    break;
            }

            previousValue = width;
        }

        void SetSliderPosition(float val)
        {
            switch (FillType)
            {
                case ProgressBarType.FillFromCenter:
                    ValueSlider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, val);
                    break;
                case ProgressBarType.FillFromLeft:
                    ValueSlider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, val);
                    ValueSlider.SetLeft(Padding.x);
                    break;
                case ProgressBarType.FillFromRight:
                    ValueSlider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, val);
                    ValueSlider.SetRight(Padding.y);
                    break;
            }
        }

        public void SetValue(ulong value, ulong maxValue)
        {
            StartCoroutine(SetWidth(value, maxValue));
        }
    }

    public enum ProgressBarType
    {
        FillFromCenter,
        FillFromLeft,
        FillFromRight
    }

    public enum ProgressTransitionType
    {
        Instant,
        Lerp,
        SmoothStep
    }
}