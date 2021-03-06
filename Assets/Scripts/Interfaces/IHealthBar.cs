using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthBar
{
    public void HandleHealthChange(float percentage);
    public IEnumerator UpdateHealthBar(float percentage);
}
