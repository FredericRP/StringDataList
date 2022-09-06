using UnityEngine;

namespace FredericRP.StringDataList
{
  public class SelectAttribute : PropertyAttribute
  {
    public string identifier;
    public bool showWarning = false;

    public SelectAttribute(string identifier)
    {
      this.identifier = identifier;
      this.showWarning = false;
    }
    public SelectAttribute(string identifier, bool showWarning)
    {
      this.identifier = identifier;
      this.showWarning = showWarning;
    }
  }
}