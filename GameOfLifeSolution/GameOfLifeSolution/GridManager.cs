using System;
using System.Drawing;

namespace GameOfLife
{
    public class GridManager
    {
        private int rows;
        private int cols;
        private bool[,] currentGrid;
        private bool[,] nextGrid;

        public GridManager(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            currentGrid = new bool[rows, cols];
            nextGrid = new bool[rows, cols];
            InitGrid();
        }

        public void InitGrid()
        {
            Random rand = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    currentGrid[row, col] = rand.Next(2) == 0;
                }
            }
        }

        public void UpdateGrid()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int aliveNeighbors = CountAliveNeighbors(row, col);
                    if (currentGrid[row, col])
                    {
                        nextGrid[row, col] = (aliveNeighbors == 2 || aliveNeighbors == 3);
                    }
                    else
                    {
                        nextGrid[row, col] = (aliveNeighbors == 3);
                    }
                }
            }
            Array.Copy(nextGrid, currentGrid, currentGrid.Length);
        }

        private int CountAliveNeighbors(int row, int col)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int newRow = row + i;
                    int newCol = col + j;
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        if (currentGrid[newRow, newCol]) count++;
                    }
                }
            }
            return count;
        }

        public void DrawGrid(Graphics g)
        {
            int cellSize = 10;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var cellColor = currentGrid[row, col] ? Brushes.Black : Brushes.White;
                    g.FillRectangle(cellColor, col * cellSize, row * cellSize, cellSize, cellSize);
                    g.DrawRectangle(Pens.Gray, col * cellSize, row * cellSize, cellSize, cellSize);
                }
            }
        }
    }
}
