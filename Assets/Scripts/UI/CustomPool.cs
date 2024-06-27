using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Screpts.UI
{
    public class CustomPool : MonoBehaviour
    {
        [Range(1,40)]
        [SerializeField] private int _numberObjectsStart;
        [SerializeField] private Model _prefab;
        [SerializeField] private Transform _container;
        private List<Model> _pool = new List<Model>();

        public void Spawn(int powerClick)
        {
            for (int i = 0; i < _numberObjectsStart; i++)
            {
                Model obj = Create(_prefab, _container);
                obj.SetPowerClick(powerClick);
                obj.gameObject.SetActive(false);
                _pool.Add(obj);
            }
        }

        public void Activate(int powerClick)
        {
            Model item = _pool.FirstOrDefault(x => !x.isActiveAndEnabled);
            if(item == null)
            {
                item = Create(_prefab, _container);
                item.SetPowerClick(powerClick);
                item.gameObject.SetActive(false);
                _pool.Add(item);
            }
            item.gameObject.SetActive(true);
        }

        public void UpdateClickPower(int powerClic)
        {
            foreach (Model obj in _pool)
            {
                obj.SetPowerClick(powerClic);
            }
        }

        private Model Create(Model prefab,Transform container)
        {
            Model objectClick = Instantiate(prefab,container);
            return objectClick;
        }
    }
}