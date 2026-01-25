using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class SaveData
{
    public List<string> resourceName = new List<string>();
    public List<int> resourceAmount = new List<int>();

    public List<string> objectType = new List<string>();
    public List<Vector3> objectPosition = new List<Vector3>();

}
