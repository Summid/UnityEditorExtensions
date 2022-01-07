using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {
        public bool Disposed { get; private set; }
        public Rect Position { get; private set; }

        public virtual void OnGUI(Rect position)
        {
            this.Position = position;
        }

        public virtual void Dispose()
        {
            if (this.Disposed) return;
            this.OnDispose();
            this.Disposed = true;
        }

        protected abstract void OnDispose();

    }

}
