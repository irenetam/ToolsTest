using eTMS.SeleniumHelpers;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTMS.PageObjects
{
    public class BaseObject
    {
        public BaseObject()
        {
            PageFactory.InitElements(Browsers.GetDriver, this);
        }
    }
}
