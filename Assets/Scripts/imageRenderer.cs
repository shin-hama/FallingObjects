using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		var sr = GetComponent<SpriteRenderer>();
        float width = GetScreenToWorldWidth;
		sr.drawMode = SpriteDrawMode.Sliced;
		Vector3 scale;
		var orgSize = sr.size;
		if (orgSize.x > orgSize.y)
        {
			float ratio = orgSize.y / orgSize.x;
			scale = new Vector3(width, width * ratio, 1);
		} else
        {
			float ratio = orgSize.x / orgSize.y;
			scale = new Vector3(width * ratio, width, 1);
		}
		sr.size = new Vector2(1, 1);
        sr.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public static float GetScreenToWorldHeight
	{
		get
		{
			Vector2 topRightCorner = new Vector2(1, 1);
			Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
			var height = edgeVector.y * 2;
			return height;
		}
	}
	public static float GetScreenToWorldWidth
	{
		get
		{
			Vector2 topRightCorner = new Vector2(1, 1);
			Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
			var width = edgeVector.x * 2;
			return width;
		}
	}
}
