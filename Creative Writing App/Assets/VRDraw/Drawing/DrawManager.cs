using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawManager : MonoBehaviour
{
    public static DrawManager Instance;

    private Dictionary<int, PenLine> Lines = new Dictionary<int, PenLine>();

    [SerializeField]
    private LineSettings lineSettings = null;

    [SerializeField]
    private UnityEvent OnDraw = null;

    private bool CanDraw { get; set; }

    private int lineIndex = 0;

    private PenLineSettings penLineSettings;


    private void Awake()
    {
        Instance = this;

    }

    public void AllowDraw(bool isAllow)
    {
        CanDraw = isAllow;
    }

    public void Draw(Vector3 drawPosition)
    {
        if (!CanDraw)
        {
            return;
        }

        OnDraw?.Invoke();

        DebugManager.Instance.LogInfo($"{drawPosition}");

        if(Lines.Keys.Count == 0)
        {
            PenLine line = new PenLine(lineSettings);

            Lines.Add(lineIndex, line);

            line.AddNewLineRenderer(this.transform, drawPosition);
        }
        else
        {
            Lines[0].AddPoint(drawPosition);
        }

    }

    public void StopDraw()
    {
        Lines.Remove(0);
    }

    public void ShowLines()
    {
        foreach(var line in GetAllLinesInScene())
        {
            line.SetActive(true);
        }
    }

    public void HideLines()
    {
        foreach (var line in GetAllLinesInScene())
        {
            line.SetActive(false);
        }
    }

    private GameObject[] GetAllLinesInScene()
    {
        return GameObject.FindGameObjectsWithTag("Line");
    }

    public void ClearLines()
    {
        GameObject[] lines = GetAllLinesInScene();
        foreach (GameObject currentLine in lines)
        {
            LineRenderer line = currentLine.GetComponent<LineRenderer>();
            Destroy(currentLine);
        }
    }
}
