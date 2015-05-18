using System;

namespace Emotions.Services.Engine
{
    class EngineUpdateEventArgs : EventArgs
    {
        public readonly EngineFrame EngineFrame;

        public EngineUpdateEventArgs(EngineFrame engineFrame)
        {
            EngineFrame = engineFrame;
        }
    }
}