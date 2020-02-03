using Exsersewo.UI.Canvas;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerCanvasManager playerCanvas;
    public Exsersewo.UI.Canvas.CanvasManager GameCanvasManager;
#if UNITY_EDITOR
    public bool DefaultToSceneView = false;
#endif

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        if (DefaultToSceneView)
        {
            EditorWindow.FocusWindowIfItsOpen(typeof(SceneView));
        }
#endif

        if (instance == null)
            instance = this;

        GameCanvasManager.ChangeToCanvas(MenuType.Game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
