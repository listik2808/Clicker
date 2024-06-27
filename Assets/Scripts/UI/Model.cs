using UnityEngine;

namespace Screpts.UI
{
    public abstract class Model: MonoBehaviour
    {
        protected int _powerClick;

        public void SetPowerClick(int powerClick)
        {
            _powerClick = powerClick;
        }
    }
}