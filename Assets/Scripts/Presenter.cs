using Screpts.Ui;
using Scripts.Ui.ButtonUI;
using UnityEngine;

namespace Screpts
{
    public class Presenter : MonoBehaviour
    {
        private ClickPanel _clickPanel;
        private CustomPool _customPool;
        public Presenter(ClickPanel clickPanel,CustomPool customPool)
        {
            _clickPanel = clickPanel;
            _customPool = customPool;
        }

        private void OnDisable()
        {
            _clickPanel.OnClickPanel -= GetClic;
        }

        private void Start()
        {
            _clickPanel.OnClickPanel += GetClic;
            _customPool.Spawn();
        }

        private void GetClic()
        {
            _customPool.Activate();


        }

    }
}