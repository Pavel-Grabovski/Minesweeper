﻿
namespace Minesweeper.Shared.Model;

public class Field
{
    private readonly bool[,] _field;

    public Field()
    {
        _field = GenerateBombs();
    }

    public bool[,] GetFieldArray() => _field;

    private bool[,] GenerateBombs()
    {
        int rows = 12; // Количество строк, лимит телеграм по высоте
        int cols = 8; // Количество столбцов - лимит кнопок в строку
        double bombProbability = 0.15; // Вероятность появления бомбы

        Random random = new Random();
        bool[,] field = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (random.NextDouble() <= bombProbability)
                    field[i, j] = true; // Бомба
                else
                    field[i, j] = false; // Пустая клетка
            }
        }

        return field;
    }
}