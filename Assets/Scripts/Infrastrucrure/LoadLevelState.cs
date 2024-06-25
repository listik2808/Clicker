﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Screpts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine,SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            var Hud = Resources.Load<GameObject>("Hud");
            var prefabhud = Object.Instantiate(Hud);
        }
    }
}