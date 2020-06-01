using Emag_Tests_Site.Utils.Selenium;
using System;

namespace Emag_Tests_Site.Pages
{
    // An abstract class cannot be instantiated. The purpose of an abstract class is to provide
    // a common definition of a base class that multiple derived classes can share.
    public abstract class Page
    {
        // A generic method is a method that is declared with type parameters.

        // Generic method named InstanceOf and is parameterless
        // where - is a generic type contraint
        // T is BasePage or a derive of BasePage
        // pageClass is an object of T type created using the new keyword and object initializer syntax.
        // It includes the property, Driver of type IWebdriver.This property is located in the the BasePage class
        // We set its value to Browser, the method located in the Driver class.
        // We use var to make the object declaration implicit, instead of using the explicit T type

        protected T InstanceOf<T>() where T : BasePage, new()
        {
            var pageClass = new T { Driver = Driver.Browser() };
            var pageType = pageClass.GetType();
            Console.WriteLine(":: The type of the page is" + pageType);
            return pageClass;
        }
    }
}
