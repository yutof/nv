using UnityEngine;
using UrFairy;

namespace Navigator.View
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private GameObject Grid;

        void Start()
        {
            CreateStage();
        }

        private void CreateStage()
        {
            const float cellWidth = 5f;
            for (var i = 0; i < Mathf.CeilToInt(Config.ScreenWidth/Config.GridWidth); i++)
            {
                var g = CreateGrid(new Vector2(cellWidth, Config.ScreenWidth));
                g.transform.LocalPosition(p=>p.X(Config.GridWidth * i - Config.ScreenWidth/2f));
            }

            for (var i = 0; i < Mathf.CeilToInt(Config.ScreenHeight/Config.GridWidth); i++)
            {
                var g = CreateGrid(new Vector2(Config.ScreenWidth, cellWidth));
                g.transform.LocalPosition(p=>p.Y(Config.ScreenHeight/2f - Config.GridWidth * i));
            }
        }

        private GameObject CreateGrid(Vector2 size)
        {
            var g = GameObject.Instantiate(Grid);
            g.transform.SetParent(transform);
            g.transform.Identity();
            g.GetComponent<RectTransform>().sizeDelta = size;
            return g;
        }
    }
}
