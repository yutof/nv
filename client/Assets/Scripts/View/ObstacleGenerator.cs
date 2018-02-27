using UnityEngine;
using UrFairy;

namespace Navigator.View
{
  public class ObstacleGenerator : MonoBehaviour
  {
    [SerializeField] private GameObject Obstacle;

    public GameObject Generate(int cellX, int cellY)
    {
      var g = Instantiate(Obstacle);
      g.transform.SetParent(transform);
      g.transform.Identity();
      g.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(Config.GridWidth/2f + cellX * Config.GridWidth, -Config.GridWidth/2f - cellY * Config.GridWidth);
      return g;
    }
  }
}

