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