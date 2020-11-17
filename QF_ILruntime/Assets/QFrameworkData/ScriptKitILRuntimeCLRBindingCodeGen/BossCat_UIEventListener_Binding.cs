using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class BossCat_UIEventListener_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(BossCat.UIEventListener);
            args = new Type[]{typeof(UnityEngine.GameObject)};
            method = type.GetMethod("Get", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Get_0);

            field = type.GetField("onScrollbarBeginChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onScrollbarBeginChanged_0);
            app.RegisterCLRFieldSetter(field, set_onScrollbarBeginChanged_0);
            field = type.GetField("onScrollbarEndChanged", flag);
            app.RegisterCLRFieldGetter(field, get_onScrollbarEndChanged_1);
            app.RegisterCLRFieldSetter(field, set_onScrollbarEndChanged_1);


        }


        static StackObject* Get_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.GameObject @go = (UnityEngine.GameObject)typeof(UnityEngine.GameObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = BossCat.UIEventListener.Get(@go);

            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_onScrollbarBeginChanged_0(ref object o)
        {
            return ((BossCat.UIEventListener)o).onScrollbarBeginChanged;
        }
        static void set_onScrollbarBeginChanged_0(ref object o, object v)
        {
            ((BossCat.UIEventListener)o).onScrollbarBeginChanged = (BossCat.UIEventListener.VoidDelegate)v;
        }
        static object get_onScrollbarEndChanged_1(ref object o)
        {
            return ((BossCat.UIEventListener)o).onScrollbarEndChanged;
        }
        static void set_onScrollbarEndChanged_1(ref object o, object v)
        {
            ((BossCat.UIEventListener)o).onScrollbarEndChanged = (BossCat.UIEventListener.VoidDelegate)v;
        }


    }
}
