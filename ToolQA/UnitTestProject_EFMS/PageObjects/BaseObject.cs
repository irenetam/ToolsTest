using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.SeleniumHelpers;

namespace UnitTestProject_EFMS.PageObjects
{
    public class BaseObject
    {
        public BaseObject()
        {
            PageFactory.InitElements(Browsers.getDriver, this);
        }
    }
}
