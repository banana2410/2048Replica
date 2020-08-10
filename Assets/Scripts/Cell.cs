using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int rowPos;
    public int columnPos;
    public int Value;
    private TextMeshPro Text;


    public void SetRowAndColumn(int rowP, int columnP)
    {
        rowPos = rowP;
        columnPos = columnP;
    }
    private void Awake()
    {
        transform.position = new Vector3(-3, -3, 0);
        Text = gameObject.GetComponentInChildren<TextMeshPro>();
}

        private void Update()
        {

        }
        public void SetValue(int value)
        {
            Value = value;
            changeText();
        }
        private void changeText()
        {
            if (Value == 0)
                Text.text = String.Empty;
            else
                Text.text = Value.ToString();
        }
        public bool HasValue()
        {
            return Value > 0;
        }
    }
