using System;
using System.Collections.Generic;

class SquareMatrix
{
    private List<List<int>> _matrix;
    private int _size;

    public SquareMatrix(int size)
    {
        _size = size;
        _matrix = new List<List<int>>();

        for (int rowIndex = 0; rowIndex < size; ++rowIndex)
        {
            _matrix.Add(new List<int>());
            for (int columnIndex = 0; columnIndex < size; ++columnIndex)
            {
                _matrix[rowIndex].Add(new Random().Next(100));
            }
        }
    }

    public void PrintMatrix()
    {
        for (int rowIndex = 0; rowIndex < _size; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
            {
                Console.Write(_matrix[rowIndex][columnIndex] + "\t");
            }
            Console.WriteLine();
        }
    }
}

public SquareMatrix Add(SquareMatrix other)
{
    SquareMatrix result = new SquareMatrix(_size);
    for (int rowIndex = 0; rowIndex < _size; ++rowIndex)
    {
        for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
        {
            result._matrix[rowIndex][columnIndex] = _matrix[rowIndex][columnIndex] + other._matrix[rowIndex][columnIndex];
        }
    }
    return result;
}

public SquareMatrix Multiply(SquareMatrix other)
{
    SquareMatrix result = new SquareMatrix(_size);
    for (int rowIndex = 0; rowIndex < _size; ++rowIndex)
    {
        for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
        {
            result._matrix[rowIndex][columnIndex] = 0;
            for (int innerIndex = 0; innerIndex < _size; ++innerIndex)
            {
                result._matrix[rowIndex][columnIndex] += _matrix[rowIndex][innerIndex] * other._matrix[innerIndex][columnIndex];
            }
        }
    }
    return result;
}

public int Determinant()
{
    if (_size == 1) return _matrix[0][0];
    if (_size == 2) return _matrix[0][0] * _matrix[1][1] - _matrix[0][1] * _matrix[1][0];

    int result = 0;
    for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
    {
        SquareMatrix submatrix = GetSubmatrix(0, columnIndex);
        if (columnIndex % 2 == 0) result += _matrix[0][columnIndex] * submatrix.Determinant();
        else result -= _matrix[0][columnIndex] * submatrix.Determinant();
    }
    return result;
}

public SquareMatrix Inverse()
{
    int det = Determinant();
    SquareMatrix result = new SquareMatrix(_size);
    for (int rowIndex = 0; rowIndex < _size; ++rowIndex)
    {
        for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
        {
            SquareMatrix submatrix = GetSubmatrix(rowIndex, columnIndex);
            int sign = ((rowIndex + columnIndex) % 2 == 0) ? 1 : -1;
            result._matrix[columnIndex][rowIndex] = sign * submatrix.Determinant() / det;
        }
    }
    return result;
}

private SquareMatrix GetSubmatrix(int excludeRow, int excludeColumn)
{
    SquareMatrix submatrix = new SquareMatrix(_size - 1);
    int subRowIndex = 0;
    for (int rowIndex = 0; rowIndex < _size; ++rowIndex)
    {
        if (rowIndex == excludeRow) continue;

        int subColumnIndex = 0;
        for (int columnIndex = 0; columnIndex < _size; ++columnIndex)
        {
            if (columnIndex == excludeColumn) continue;
            submatrix._matrix[subRowIndex][subColumnIndex] = _matrix[rowIndex][columnIndex];
            ++subColumnIndex;
        }
        ++subRowIndex;
    }
    return submatrix;
}