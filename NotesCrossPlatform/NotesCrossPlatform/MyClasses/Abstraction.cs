using System;
using System.Collections.Generic;
using System.Text;

namespace NotesCrossPlatform.MyClasses
{
    class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }

        public virtual string Operation()
        {
            return _implementation.OperationImplementation();
        }
    }

}

    public interface IImplementation
    {
        string OperationImplementation();
    }

    public class Platform_iOS : IImplementation
    {
        public string OperationImplementation()
        {
             return "AppStore page of the application.\n";
        }
    }

    public class PlatformAndroid : IImplementation
    {
        public string OperationImplementation()
        {
            return "GoogleStore page of the application.\n";
        }
    }

  

