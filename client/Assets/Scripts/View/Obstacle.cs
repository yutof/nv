using UnityEngine;

namespace Navigator.View
{
  public class Obstacle : MonoBehaviour
  {
    [SerializeField] private RectTransform RectTransform;
    void Start ()
    {
      RectTransform.sizeDelta = Config.GridSize;
    }

    public void Remove()
    {
      Destroy(gameObject);
    }
  }
}
