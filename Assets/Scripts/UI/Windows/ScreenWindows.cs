using UnityEngine;

namespace Screpts.UI.Windows
{
    public abstract class ScreenWindows : MonoBehaviour
    {
        [SerializeField] protected int Index;

        public int IndexScreen => Index;
    }
}