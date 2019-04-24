using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    public static Transform[,] gameBoard = new Transform[10, 20];

    public static bool DeleteAllFullRows()
    {
        for (int row = 0; row < 20; ++row)
        {
            if (IsRowFull(row))
            {
                DeleteGBRow(row);
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.rowDelete);
                return true;
            }
        }
        return false;
    }

    public static bool IsRowFull(int row)
    {
        for (int col = 0; col < 10; ++col)
        {
            if (gameBoard[col, row] == null)
            {
                return false;
            }
        }
        return true; 
    }

    public static void DeleteGBRow(int row)
    {
        for (int col = 0; col < 10; ++col)
        {
            Destroy(gameBoard[col, row].gameObject);
            gameBoard[col, row] = null;
        }
        row++;
        for (int j = row; j < 20; ++j)
        {
            for (int col = 0; col < 10; ++col)
            {
                if (gameBoard[col, j] != null)
                {
                    gameBoard[col, j - 1] = gameBoard[col, j];
                    gameBoard[col, j] = null;
                    gameBoard[col, j - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }
}
