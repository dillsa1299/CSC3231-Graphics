using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code within script modified from:
 * https://www.youtube.com/watch?v=m9hj9PdO328&ab_channel=ProbablySpoonie
*/

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order =1)]

public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;

}
