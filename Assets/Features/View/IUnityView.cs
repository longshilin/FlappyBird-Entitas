using Entitas;
using UnityEngine;

namespace View
{
    public interface IUnityView : IView
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 Scale { get; set; }
    }
}