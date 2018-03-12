using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique]
public class MouseClickDownComponent : IComponent { }

[Input, Unique]
public class MouseClickStayComponent : IComponent { }

[Input, Unique]
public class MouseClickReleasedComponent : IComponent { }

[Input, Unique]
public class ReloadActionComponent : IComponent { }