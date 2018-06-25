using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Helpers
{
    public class SingleClick
    {
        bool hasClicked;
        #region Button Click  
        Action<object, EventArgs> _setClick;
        public SingleClick(Action<object, EventArgs> setClick)
        {
            _setClick = setClick;
        }
        #endregion Button Click  

        public void Click(object s, EventArgs e)
        {
            if (!hasClicked)
            {
                _setClick(s, e);
                hasClicked = true;
            }
            Reset();
        }
        async void Reset()
        {
            await Task.Delay(800);
            await Task.Run(new Action(() => hasClicked = false));
        }
    }
}
