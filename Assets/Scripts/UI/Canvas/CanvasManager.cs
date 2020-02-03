using System.Linq;
using UnityEngine;

namespace Exsersewo.UI.Canvas
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasManager : MonoBehaviour
    {
        public CanvasFader[] Canvases;
        public float TimeToLerp;

        void ChangeCanvas(MenuType menu, bool lerp)
        {
            var toZero = Canvases.Where(x => x.MenuType != menu).ToList();
            var toOne = Canvases.FirstOrDefault(x => x.MenuType == menu);

            toZero.ForEach(x =>
            {
                var fader = x.GetComponent<CanvasFader>();
                if (fader.Visible)
                {
                    fader.HidePanel(lerp, TimeToLerp);
                }
            });

            toOne.GetComponent<CanvasFader>().ShowPanel(lerp, TimeToLerp);
        }

        public void ChangeToCanvas(CanvasFader menu)
            => ChangeToCanvas(menu.MenuType);

        public void ChangeToCanvas(MenuType menu)
            => ChangeCanvas(menu, false);

        public void LerpToCanvas(CanvasFader menu)
            => LerpToCanvas(menu.MenuType);

        public void LerpToCanvas(MenuType menu)
            => ChangeCanvas(menu, true);
    }

    [System.Serializable]
    public enum MenuType
    {
        Game = 0,
        Stats = 1,
        Codex = 2
    }
}
