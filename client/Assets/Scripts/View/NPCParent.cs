using System.Runtime.InteropServices;
using UnityEngine;
using UrFairy;

namespace Navigator.View
{
  public class NPCParent : MonoBehaviour {
    void Start () {　gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(Config.GridWidth/2f, -Config.GridWidth/2f);}
  }
}

