﻿using Emotions.KinectTools;
using Gemini.Framework;

namespace Emotions.Services.KinectInput
{
    internal interface IKinectInputService
    {
        bool IsKinectAvailable { get; }
        IKinectSource GetKinect();
        void Dispose();
        IKinectSource LoadRecording(string path);
    }
}