using UnityEngine;
using System;

public abstract class Interactions : ScriptableObject {
	public virtual void Setup() { }
	public abstract void Interaction(Action callback);
}
