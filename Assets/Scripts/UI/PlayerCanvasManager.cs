using Exsersewo.UI.ProgressBar;
using TMPro;
using UnityEngine;

public class PlayerCanvasManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Name;

    [SerializeField]
    LabelValueHolder Level;

    [SerializeField]
    ProgressBar HealthBar;

    [SerializeField]
    ProgressBar ExperienceBar;

    public void SetNameText(string text)
        => Name.SetText(text);

    public void SetLevelValue(string text)
        => Level.Value.SetText(text);

    public void SetHealthValue(ulong value, ulong maxValue)
        => HealthBar.SetValue(value, maxValue);

    public void SetExperienceBar(ulong value, ulong maxValue)
        => ExperienceBar.SetValue(value, maxValue);
}
