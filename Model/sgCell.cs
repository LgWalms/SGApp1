using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SGApp1.Model
{
  public class sgCell : INotifyPropertyChanged
  {
    private List<bool> _candidates;   // candidate button visibility
    private int _entry;               // <1: invisible, <0: previous visible value
    public enum eDisplayMode
    {
      Entry = 0,
      Candidate = 1,
    }

    public sgCell()
    {
    }
    
    public int Entry
    {
      get
      {
        return _entry;
      }
      set
      {
        if (_entry == value)
          return;
        _entry = value;
        RaisePropertyChanged(nameof(Entry));
      }
    }

    public List<bool> Candidates
    {
      get
      {
        if (null == _candidates)
        {
          _candidates = new List<bool>(9);
          for (int i = 0; i < 9; i++)
            _candidates.Add(false);
        }
        return _candidates;
      }
      set
      {
        if (_candidates == value)
          return;
        _candidates = value;
        RaisePropertyChanged(nameof(Candidates));
      }
    }

    public eDisplayMode DisplayMode
    {
      get
      {
        if (Entry > 0)
          return eDisplayMode.Entry;
        return eDisplayMode.Candidate;
      }
    }

    public void RaisePropertyChanged(string v)
    {
      OnPropertyChanged(v);
    }

    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
