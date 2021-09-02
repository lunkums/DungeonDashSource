using UnityEngine;
using TMPro;

public class ScoreCounterVisual : MonoBehaviour
{
    [SerializeField] private RectTransform anchorPosition;
    [SerializeField] private TMP_Text text;

    private ScoreCounterSystem scoreCounterSystem;

    private void Start()
    {
        scoreCounterSystem = new ScoreCounterSystem(GameManager.instance.Player);
        AlignText();
    }

    private void Update()
    {
        text.SetText(scoreCounterSystem.GetScore().ToString());
    }

    private void AlignText()
    {
        var sizeDelta = text.rectTransform.sizeDelta;
        var width = sizeDelta.x;
        var height = sizeDelta.y;
        var offset = new Vector2(0, -4);
        text.rectTransform.localPosition = new Vector2(-width / 2 + offset.x, -height / 2 + offset.y);
    }
}
