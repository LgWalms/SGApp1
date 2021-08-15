using System;
using System.Collections.Generic;
using System.Text;

namespace SGApp1.Model
{
  class sgGrid
  {
    private sgCell[,] _cells;

    public sgCell[,] Cells
    {
      get
      {
        if(null == _cells)
          _cells = new sgCell[9, 9];
        return _cells;
      }
    }

    public sgCell Cell(int icol, int irow)
    {
      CheckCellIndex("column index", icol);
      CheckCellIndex("row index", irow);
      return Cells[icol, irow];
    }

    public sgCell.eDisplayMode CellDisplayMode(int icol, int irow)
    {
      return Cell(icol, irow).DisplayMode;
    }

    void CheckCellIndex(string name, int idx)
    {
      if (idx < 0 || idx > 8)
        throw new ArgumentOutOfRangeException(name);
    }

  }
}