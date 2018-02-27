using System.Collections.Generic;
using Navigator.Model.Data;
using UnityEngine;
using Navigator.View;
namespace Navigator.Model
{
  public class StageController : MonoBehaviour
  {
    [SerializeField] private ObstacleGenerator ObstacleGenerator;
    [SerializeField] private StageTouchDetector StageTouchDetector;

    private Dictionary<CellPosition, Obstacle> ObstacleDictionary;

    void Start()
    {
      ObstacleDictionary = new Dictionary<CellPosition, Obstacle>();
      StageTouchDetector.SetOnCellClicked(OnCellCkecked);
    }

    private void OnCellCkecked(int cellX, int cellY)
    {
      var cellPosition = new CellPosition(cellX, cellY);
      Debug.Log($"on cell clicked {cellPosition}  contains? {ObstacleDictionary.ContainsKey(cellPosition)}");

      if (ObstacleDictionary.ContainsKey(cellPosition))
      {
        ObstacleDictionary[cellPosition].Remove();
        ObstacleDictionary.Remove(cellPosition);
      }
      else
      {
        var go = ObstacleGenerator.Generate(cellX, cellY);
        ObstacleDictionary.Add(cellPosition, go.GetComponent<Obstacle>());
      }
    }
  }
}
