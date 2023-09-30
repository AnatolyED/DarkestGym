using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCoordinate : MonoBehaviour
{
    [SerializeField] private int _rowNum;
    [SerializeField] private int _diagonalFirstNum;
    [SerializeField] private int _diagonalSecondNum;

    public int RowNum
    {
        get { return _rowNum; }
        set { _rowNum = value; }
    }
    public int DiagonalFirstNum
    {
        get { return _diagonalFirstNum; }
        set { _diagonalFirstNum = value; }
    }
    public int DiagonalSecondNum
    {
        get { return _diagonalSecondNum; }
        set { _diagonalSecondNum = value; }
    }

    public static int Dist(CellCoordinate cc1, CellCoordinate cc2)
    {
        int firstDigDiff = Math.Abs(cc1.DiagonalFirstNum - cc2.DiagonalFirstNum);
        int secondDigDiff = Math.Abs(cc1.DiagonalSecondNum - cc2.DiagonalSecondNum);
        int rowDiff = Math.Abs(cc1.RowNum - cc2.RowNum);

        int sum1 = firstDigDiff + secondDigDiff;
        int sum2 = secondDigDiff + rowDiff;
        int sum3 = rowDiff + firstDigDiff;

        return Math.Min(sum1, Math.Min(sum2, sum3));
    }

    public override string ToString()
    {
        return $"RowNum: {_rowNum} | DiagonalFirstNum: {_diagonalFirstNum} | DiagonalSecondNum: {_diagonalSecondNum}";
    }
}
