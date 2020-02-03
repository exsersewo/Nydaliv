using Exsersewo.Nydaliv.Extensions;
using System.Collections;
using UnityEngine;

namespace Exsersewo.UI.Canvas
{
    public class CanvasFader : MonoBehaviour
    {
        public MenuType MenuType;
        public bool Visible => GetComponent<CanvasGroup>().alpha > 0.9f;

        IEnumerator ChangeVisibility(bool lerp, bool show, float TimeToLerp)
        {
            float timeLerped = 0;

            var group = GetComponent<CanvasGroup>();

            group.interactable = group.blocksRaycasts = show;

            if (lerp)
            {
                while (timeLerped < TimeToLerp)
                {
                    var lerped = Mathf.Lerp(0, 1, timeLerped / TimeToLerp);

                    if (lerped > 0.9)
                        lerped = 1;
                    else if (lerped < 0.1)
                        lerped = 0;

                    group.alpha = show ? lerped : 1 - lerped;

                    timeLerped += Time.unscaledDeltaTime;

                    yield return null;
                }
            }
            else
            {
                group.alpha = show ? 1 : 0;
            }

            yield return null;
        }

        public void HidePanel(bool lerp, float TimeToLerp)
        {
            StartCoroutine(ChangeVisibility(lerp, false, TimeToLerp));
        }

        public void ShowPanel(bool lerp, float TimeToLerp)
        {
            StartCoroutine(ChangeVisibility(lerp, true, TimeToLerp));
        }
    }
}