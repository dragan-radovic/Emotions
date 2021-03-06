﻿using System.ComponentModel.Composition;
using Emotions.KinectTools.Sources;
using Gemini.Framework;
using Gemini.Framework.Services;

namespace Emotions.Modules.Engine.ViewModels
{
    [Export(typeof(EngineControlViewModel))]
    class EngineControlViewModel : Tool
    {
        private readonly IEngineService _engine;

        [ImportingConstructor]
        public EngineControlViewModel(IEngineService engineService)
        {
            _engine = engineService;
        }

        public override PaneLocation PreferredLocation
        {
            get { return PaneLocation.Left; }
        }

        public EngineControlViewModel()
        {
            DisplayName = "Engine control panel";
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            _engine.SourceChanged += EngineOnSourceChanged;
        }

        private void EngineOnSourceChanged(IEngineService engineService, IKinectSource kinectSource)
        {
            NotifyOfPropertyChange(() => SourceName);
            NotifyOfPropertyChange(() => IsRunning);                
        }

        public string SourceName
        {
            get
            {
                if (_engine.ActiveSource == null)
                    return "None";
                return _engine.ActiveSource.Name;
            }
        }

        public bool IsRunning
        {
            get { return _engine.IsRunning; }
            set
            {
                if(!value)
                    _engine.Stop();
                NotifyOfPropertyChange(() => IsRunning);
            }
        }
    }
}