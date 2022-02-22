using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public static class RectExtension
    {

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