using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using TwinStick.Utils;
using UniRx;
using UnityEngine;

namespace TwinStick.Inputs
{
    public class InputsSytem : IInitializeSystem, IExecuteSystem, ICleanupSystem
    {
        private readonly InputContext _context;
        private readonly InputSettings _settings;
        public InputsSytem (Contexts contexts, InputSettings settings)
        {
            _context = contexts.input;
            _settings = settings;
        }
        public void Initialize ()
        {
            var updateObs = Observable.EveryUpdate ().AsUnitObservable ();

            updateObs.Where (_ => Input.GetMouseButtonDown (0)).Subscribe (_ => _context.isMouseClickDown = true);
            updateObs.Where (_ => Input.GetMouseButton (0)).Subscribe (_ => _context.isMouseClickStay = true);
            updateObs.Where (_ => Input.GetMouseButtonUp (0)).Subscribe (_ => _context.isMouseClickReleased = true);

            updateObs.Where (_ => Input.GetMouseButtonDown (0)).Buffer (TimeSpan.FromMilliseconds (_settings.DoubleClickDelay)).Where (x => x.Count >= 2).Subscribe (_ => _context.isReloadAction = true);
        }

        public void Execute ()
        {
            _context.ReplaceMousePosition (Input.mousePosition);
            _context.ReplaceMoveInput (new Vector2 (
                Input.GetAxisRaw (_settings.XAxisName),
                Input.GetAxisRaw (_settings.YAxisName)
            ));

        }

        public void Cleanup ()
        {
            _context.isMouseClickDown = false;
            _context.isMouseClickReleased = false;
            _context.isMouseClickStay = false;
            _context.isReloadAction = false;
        }
    }

}