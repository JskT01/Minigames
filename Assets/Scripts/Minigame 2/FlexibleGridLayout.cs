using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        //float sqrRt = Mathf.Sqrt(transform.childCount);
        //rows = Mathf.CeilToInt(sqrRt);
        //columns = Mathf.CeilToInt(sqrRt);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)columns)-((columns-1)*(spacing.x/(float)columns))/*-(padding.left/ (float)columns)- (padding.right / (float)columns)*/;
        float cellHeight = (parentHeight / (float)rows) - ((rows - 1) * (spacing.y/(float)rows-1))/* - (padding.top / (float)rows) - (padding.bottom / (float)rows)*/;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        int columnCount = 0;
        int rowCount = 0;
        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount)+(spacing.x*columnCount)+padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount)+padding.bottom;
            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
            
    }


    public override void CalculateLayoutInputVertical()
    {

    }
    public override void SetLayoutHorizontal()
    {

    }
    public override void SetLayoutVertical()
    {

    }
}


