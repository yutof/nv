using System;
using UnityEngine;

namespace Navigator.View
{
    public class StageTouchDetector : MonoBehaviour
    {
        [SerializeField] private Canvas Canvas;
        private Action<int, int> OnCellClicked;
        public void SetOnCellClicked(Action<int, int> a) => OnCellClicked = a;

        private void Update()
        {
            if (Input.mousePresent && Input.GetMouseButtonDown(0))
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, Input.mousePosition, Canvas.worldCamera, out pos);
                OnTouchDetected(pos.x+Config.ScreenWidth/2f, Mathf.Abs(pos.y-Config.ScreenHeight/2f));
            }
            else
            {
                if(Input.touchCount < 1)
                    return;
                var touch = Input.GetTouch(0);
                OnTouchDetected(touch.position.x, touch.position.y);
            }
        }

        private void OnTouchDetected(float xPos, float yPos)
        {
            var cellX = Mathf.FloorToInt(xPos / (Config.GridWidth));
            var cellY = Mathf.FloorToInt(yPos  / (Config.GridWidth));
            OnCellClicked?.Invoke(cellX,cellY);
        }

    }
}

