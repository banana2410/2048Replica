using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovingDir { Left, Right, Up, Down }
public class Board : MonoBehaviour
{
    private SwipeInput _swipeInput;
    public Cell cellPrefab;
    private static int _numberOfRows = 3;
    private static int _numberOfColumns = 3;
    public Cell[,] _cells;
    private List<Cell> _emptyCells = new List<Cell>();

    private MovingDir movingDir;

    public GameObject gameOver;
    public bool didMove;
    public bool didPopulate;

    private void Start()
    {
        _swipeInput = gameObject.GetComponent<SwipeInput>();
        generateCells();
        RandomGenerate();
    }

    private void generateCells()
    {
        _cells = new Cell[_numberOfRows, _numberOfColumns];
        for (int r = 0; r < _numberOfRows; r++)
        {
            for (int c = 0; c < _numberOfColumns; c++)
            {
                _cells[r, c] = Instantiate(cellPrefab);
                _cells[r, c].SetRowAndColumn(r, c);
                _cells[r, c].gameObject.transform.position = new Vector3(_cells[r, c].transform.position.y + _cells[r, c].columnPos * 3, _cells[r, c].transform.position.x + _cells[r, c].rowPos * 3, 0f);
            }
        }

    }

    public void RandomGenerate()
    {
        int row = Random.Range(0, 3);
        int column = Random.Range(0, 3);

        _cells[row, column].SetValue(2);
        _cells[column, row].SetValue(2);

    }
    private void Update()
    {
        if(SwipeInput.swipedDown)
        {
            didMove = false;
            didPopulate = false;
            foreach (Cell cell in _cells)
            {
                MoveDown(cell);
            }

            Populate();
            if (!didMove)
            {
                gameOver.SetActive(true);
            }

        } 
        if(SwipeInput.swipedUp)
        {
            didMove = false;
            didPopulate = false;
            foreach (Cell cell in _cells)
            {
                MoveUp(cell);
            }

            Populate();
            if (!didMove)
            {
                gameOver.SetActive(true);
            }

        } 
        if(SwipeInput.swipedLeft)
        {
            didMove = false;
            didPopulate = false;
            foreach (Cell cell in _cells)
            {
                MoveLeft(cell);
            }

            Populate();
            if (!didMove )
            {
                gameOver.SetActive(true);
            }

        } 
        if(SwipeInput.swipedRight)
        {
            didMove = false;
            didPopulate = false;
            foreach (Cell cell in _cells)
            {
                MoveRight(cell);
            }

            Populate();
            if (!didMove)
            {
                gameOver.SetActive(true);
            }
        }
    }

    private void Populate()
    {
        _emptyCells.Clear();
        foreach (Cell cell in _cells)
        {
            if (!cell.HasValue())
            {
                _emptyCells.Add(cell);
            }
        }
        int randomCellNumber = Random.Range(0, _emptyCells.Count);
        _emptyCells[randomCellNumber].SetValue(2);
        _emptyCells.Remove(_emptyCells[randomCellNumber]);
        if(_emptyCells.Count > 0)
        {
            didPopulate = true;
        }
     
    }
    public void MoveLeft(Cell cell)
    {
        if (cell.columnPos > 0 && cell.HasValue())
        {
            if (_cells[cell.rowPos, cell.columnPos - 1].Value == cell.Value)
            {
                _cells[cell.rowPos, cell.columnPos - 1].SetValue(_cells[cell.rowPos, cell.columnPos - 1].Value += _cells[cell.rowPos, cell.columnPos - 1].Value);
                cell.SetValue(0);
                didMove = true;
            }
            if (!_cells[cell.rowPos, cell.columnPos - 1].HasValue())
            {
                _cells[cell.rowPos, cell.columnPos - 1].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }
            if (!_cells[cell.rowPos, cell.columnPos - 1].HasValue())
            {
                _cells[cell.rowPos, cell.columnPos - 1].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }

        }
    }
    public void MoveRight(Cell cell)
    {
        if (cell.columnPos < 2 && cell.HasValue())
        {
            if (_cells[cell.rowPos, cell.columnPos + 1].Value == cell.Value)
            {
                _cells[cell.rowPos, cell.columnPos + 1].SetValue(_cells[cell.rowPos, cell.columnPos + 1].Value += _cells[cell.rowPos, cell.columnPos + 1].Value);
                cell.SetValue(0);
                didMove = true;
            }
            if (!_cells[cell.rowPos, cell.columnPos + 1].HasValue())
            {
                _cells[cell.rowPos, cell.columnPos + 1].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            } 
            if (!_cells[cell.rowPos, cell.columnPos + 1].HasValue())
            {
                _cells[cell.rowPos, cell.columnPos + 1].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }

        }
    }
    public void MoveUp(Cell cell)
    {
        if (cell.rowPos < 2 && cell.HasValue())
        {
            if (_cells[cell.rowPos + 1, cell.columnPos].Value == cell.Value)
            {
                _cells[cell.rowPos + 1, cell.columnPos].SetValue(_cells[cell.rowPos + 1, cell.columnPos].Value += _cells[cell.rowPos + 1, cell.columnPos].Value);
                didMove = true;
              
            }
            if (!_cells[cell.rowPos + 1, cell.columnPos].HasValue())
            {
                _cells[cell.rowPos + 1, cell.columnPos].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }    
            if (!_cells[cell.rowPos + 1, cell.columnPos].HasValue())
            {
                _cells[cell.rowPos + 1, cell.columnPos].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }

        }
    }
    public void MoveDown(Cell cell)
    {
        if (cell.rowPos > 0 && cell.HasValue())
        {
            if (_cells[cell.rowPos - 1, cell.columnPos].Value == cell.Value)
            {
                _cells[cell.rowPos - 1, cell.columnPos].SetValue(_cells[cell.rowPos - 1, cell.columnPos].Value += _cells[cell.rowPos - 1, cell.columnPos].Value);
                cell.SetValue(0);
                didMove = true;
            }
            if (!_cells[cell.rowPos - 1, cell.columnPos].HasValue())
            {
                _cells[cell.rowPos - 1, cell.columnPos].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }   
            if (!_cells[cell.rowPos - 1, cell.columnPos].HasValue())
            {
                _cells[cell.rowPos - 1, cell.columnPos].SetValue(cell.Value);
                cell.SetValue(0);
                didMove = true;
            }
        }
    }



}

