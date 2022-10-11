using UnityEngine;

namespace FredericRP.StringDataList
{
  public class SelectAttribute : PropertyAttribute
  {
    public string identifier;
    public bool showWarning = false;

    public SelectAttribute(string identifier, bool showWarning = false)
    {
      this.identifier = identifier;
      this.showWarning = showWarning;
    }
  }
}