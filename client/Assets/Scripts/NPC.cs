using System.Collections;
using UnityEngine;
using Uween;
using UrFairy;
namespace Navigator
{
    public class NPC : MonoBehaviour {

        void Start ()
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = Config.GridSize;
            gameObject.transform.Identity();
            StartCoroutine(MoveNPC());
        }


        IEnumerator MoveNPC()
        {
            yield return  new WaitForSeconds(0.5f);
            MoveNPCRecursively(gameObject);
        }

        void MoveNPCRecursively(GameObject go)
        {
            Move(go, 0f, 1f)
                .Then(() => Move(go, 1f , 1f)
                .Then(() => Move(go, 1f , 0f)
                .Then(() => Move(go, 0f , 0f)
                .Then(() => MoveNPCRecursively(go)))));
        }

        Tween Move(GameObject go, float x, float y)
        {
            const float duration = 0.8f;
            var xValue = x * Config.GridWidth;
            var yValue = y * Config.GridWidth;
            return TweenXY.Add(go, duration, xValue, yValue).EaseInOutCubic().Delay(0.5f);
        }
    }
}

