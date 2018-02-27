using System;
using System.Diagnostics;

namespace Navigator.Model.Data
{
  public class CellPosition: IEquatable<CellPosition>
  {
    public readonly int X;
    public readonly int Y;

    public CellPosition(int x, int y)
    {
      X = x;
      Y = y;
    }

    public override string ToString()
    {
      return $"X:{X} Y:{Y}";
    }

    public override int GetHashCode()
    {
      return X ^ Y;
    }

    public bool Equals(CellPosition cell)
    {
      Debug.Assert(cell != null, nameof(cell) + " != null");
      return cell.X == X && cell.Y == Y;
    }
  }
}

