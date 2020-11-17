using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    partial class CLRBindings
    {

        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector2> s_UnityEngine_Vector2_Binding_Binder = null;
        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector3> s_UnityEngine_Vector3_Binding_Binder = null;
        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector4> s_UnityEngine_Vector4_Binding_Binder = null;
        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Quaternion> s_UnityEngine_Quaternion_Binding_Binder = null;

        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        static partial void OnInitialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            System_Collections_Generic_Dictionary_2_String_RecordTable_Binding.Register(app);
            PathTool_Binding.Register(app);
            System_IO_File_Binding.Register(app);
            ResourceIOTool_Binding.Register(app);
            System_String_Binding.Register(app);
            RecordTable_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_SingleField_Binding.Register(app);
            UnityEngine_Application_Binding.Register(app);
            FileTool_Binding.Register(app);
            LitJson_JsonMapper_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Dictionary_2_Int32_String_Binding.Register(app);
            System_Convert_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_String_Binding.Register(app);
            System_Char_Binding.Register(app);
            System_Type_Binding.Register(app);
            UnityEngine_Resources_Binding.Register(app);
            System_Object_Binding.Register(app);
            System_Enum_Binding.Register(app);
            System_Array_Binding.Register(app);
            System_Collections_IEnumerator_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Dictionary_2_Int32_String_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_Dictionary_2_Int32_String_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Dictionary_2_Int32_Int32_Binding.Register(app);
            System_Int32_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            System_Collections_Generic_List_1_String_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            QFramework_Property_1_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Byte_Binding.Register(app);
            System_Net_Dns_Binding.Register(app);
            System_Net_IPHostEntry_Binding.Register(app);
            System_Net_IPEndPoint_Binding.Register(app);
            System_Net_Sockets_Socket_Binding.Register(app);
            System_DateTime_Binding.Register(app);
            System_TimeZone_Binding.Register(app);
            UnityEngine_PlayerPrefs_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_List_1_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding.Register(app);
            System_TimeSpan_Binding.Register(app);
            UniRx_Observable_Binding.Register(app);
            UniRx_ObservableExtensions_Binding.Register(app);
            UnityEngine_Component_Binding.Register(app);
            QFramework_ILComponentBehaviour_Binding.Register(app);
            DG_Tweening_ShortcutExtensions_Binding.Register(app);
            UnityEngine_Transform_Binding.Register(app);
            UnityEngine_Vector3_Binding.Register(app);
            DG_Tweening_TweenSettingsExtensions_Binding.Register(app);
            QFramework_ResKit_Binding.Register(app);
            QFramework_ResLoader_Binding.Register(app);
            UniRx_DisposableExtensions_Binding.Register(app);
            UnityEngine_UI_Slider_Binding.Register(app);
            UnityEngine_SceneManagement_SceneManager_Binding.Register(app);
            System_Collections_Generic_List_1_Image_Binding.Register(app);
            UnityEngine_UI_Text_Binding.Register(app);
            UnityEngine_U2D_SpriteAtlas_Binding.Register(app);
            UnityEngine_UI_Image_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Dictionary_2_Int32_Int32_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_Dictionary_2_Int32_Int32_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            UnityEngine_Color_Binding.Register(app);
            UnityEngine_UI_Selectable_Binding.Register(app);
            UnityEngine_UI_Graphic_Binding.Register(app);
            QFramework_ObjectExtension_Binding.Register(app);
            System_Collections_Generic_List_1_Text_Binding.Register(app);
            UnityEngine_Vector2_Binding.Register(app);
            UnityEngine_RectTransform_Binding.Register(app);
            System_Collections_Generic_List_1_GameObject_Binding.Register(app);
            UnityEngine_Events_UnityEventBase_Binding.Register(app);
            DG_Tweening_TweenExtensions_Binding.Register(app);
            QFramework_GameObjectExtension_Binding.Register(app);
            DXUtils_Binding.Register(app);
            DG_Tweening_DOTween_Binding.Register(app);
            UnityEngine_Random_Binding.Register(app);
            DG_Tweening_DOTweenModuleUI_Binding.Register(app);
            System_Single_Binding.Register(app);
            UnityEngine_Mathf_Binding.Register(app);
            UnityEngine_Input_Binding.Register(app);
            System_Collections_Generic_List_1_Int32_Binding_Enumerator_Binding.Register(app);
            System_Double_Binding.Register(app);
            UnityEngine_Color32_Binding.Register(app);
            BossCat_UIEventListener_Binding.Register(app);
            UniRx_UnityUIComponentExtensions_Binding.Register(app);
            QFramework_UIKit_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            UnityEngine_SceneManagement_Scene_Binding.Register(app);
            System_Activator_Binding.Register(app);
            System_Linq_Enumerable_Binding.Register(app);
            System_Reflection_MethodBase_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_ILTypeInstance_Type_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_ILTypeInstance_Object_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_ILTypeInstance_Binding.Register(app);
            System_Action_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Type_ILTypeInstance_Binding.Register(app);
            QFramework_DictionaryPool_2_Type_ILTypeInstance_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Vector2));
            s_UnityEngine_Vector2_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector2>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Vector3));
            s_UnityEngine_Vector3_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector3>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Vector4));
            s_UnityEngine_Vector4_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector4>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Quaternion));
            s_UnityEngine_Quaternion_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Quaternion>;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        static partial void OnShutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            s_UnityEngine_Vector2_Binding_Binder = null;
            s_UnityEngine_Vector3_Binding_Binder = null;
            s_UnityEngine_Vector4_Binding_Binder = null;
            s_UnityEngine_Quaternion_Binding_Binder = null;
        }
    }
}
