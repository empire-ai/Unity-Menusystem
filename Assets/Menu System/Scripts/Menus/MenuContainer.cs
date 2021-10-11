using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MenuSystem.Menus
{
    public class MenuContainer : MonoBehaviour
    {
        public static MenuContainer Instance;

        [SerializeField] private Transform _container    = null;
        [SerializeField] public Menu _startMenu         = null;

        public Menu Current { get; private set; }
        internal Menu[] Menus;

        internal virtual void Start()
        {
            Instance = this;

            FetchMenus();

            if (_startMenu != null)
                ShowMenu(_startMenu);
        }

        private void FetchMenus()
        {
            var menus = new List<Menu>();
            
            foreach (Transform trans in _container)
            {
                var menu = trans.GetComponent<Menu>();
                if (menu != null) menus.Add(menu);
            }
            
            Menus = menus.ToArray();
        }

        public static void ShowMenu(Menu menu)
        {
            if (menu == Instance.Current) return;

            if (Instance.Current != null)
                Instance.Current.Open = false;

            Instance.Menus
                .Where(m => m.Open)
                .ToList()
                .ForEach(m => m.Open = false);

            Instance.Current = menu;
            
            if (menu) menu.Open = true;
        }
    }
}