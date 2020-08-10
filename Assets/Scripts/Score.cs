using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Board board;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = getScore().ToString();
    }
    private int getScore()
    {
        int score = 0;
        foreach (Cell cell in board._cells)
        {
            score += cell.Value;
        }
        return score;
    }
}
