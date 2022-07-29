using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public enum AnchorType
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8,
    }

    public static class RectExtension
    {
        //���ţ�pixel��Ϊ��
        public static Rect Zoom(this Rect rect, float pixel, AnchorType anchorType)
        {
            float newWidth = rect.width + pixel;
            float newHeight = rect.height + pixel;

            //������rect���Ͻ�
            if (anchorType == AnchorType.MiddleCenter)
            {
                rect.x -= pixel * 0.5f;
                rect.y -= pixel * 0.5f;
            }
            else
            {
                //to do
            }
            rect.width = newWidth;
            rect.height = newHeight;
            return rect;
        }

        public static Rect[] VerticalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                //����Rect֮������padding�ľ���
                return new Rect[2]
                {
                    self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2)),
                    self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding/2)),
                };
            }

            return new Rect[2]
            {
                new Rect(0,0,0,0),
                new Rect(0,0,0,0)
            };
        }

        //��ȡ�м� padding �� rect
        public static Rect VerticalSplitRect(this Rect self, float width, float padding = 0)
        {
            Rect rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2));
            rect.x = rect.width + padding;
            rect.width = padding;
            return rect;
        }

        public static Rect CutRight(this Rect self, float pixels)
        {
            self.xMax -= pixels;
            return self;
        }

        public static Rect CutLeft(this Rect self, float pixels)
        {
            self.xMin += pixels;
            return self;
        }

        public static Rect CutTop(this Rect self, float pixels)
        {
            self.yMin += pixels;
            return self;
        }

        public static Rect CutButtom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }
    }
}