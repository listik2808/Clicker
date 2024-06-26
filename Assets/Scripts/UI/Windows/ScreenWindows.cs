using UnityEngine;

namespace Screpts.Ui.Windows
{
    public abstract class ScreenWindows : MonoBehaviour
    {
        [SerializeField] protected int Index;

        public int IndexScreen => Index;
    }
}