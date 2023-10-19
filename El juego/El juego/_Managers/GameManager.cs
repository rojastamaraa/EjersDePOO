using El_juego._Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_juego._Managers
{
    public class GameManager
    {
        private Tbh tbh;

        public void Init()
        {
            tbh = new();
        }

        public void Update()
        {
            InputManager.Update();
            tbh.Update();
        }

        public void Draw()
        {
            tbh.Draw();
        }
    }
}
