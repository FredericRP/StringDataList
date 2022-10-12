using System.Collections.Generic;
using UnityEngine;

namespace FredericRP.StringDataList
{
  public class DataListLoader : MonoBehaviour
  {

    public static List<string> GetDataList(string identifier)
    {
      List<string> seasonList = new List<string>();
      // Load the asset from resources
      TextAsset[] textList = Resources.LoadAll<TextAsset>("datalist/" + identifier);
      if (textList != null && textList.Length > 0)
      {
        seasonList.AddRange(textList[0].text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries));
        // If multiple data list match the same ID, add all
        // Beware that if you are using integer properties, adding a new file will modify the displayed value
        for (int i=1;i<textList.Length;i++)
        {
          string[] alternativeIdList = textList[i].text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
          seasonList.AddRange(alternativeIdList);
        }
      }
      // Return the season list
      return seasonList;
    }
  }
}