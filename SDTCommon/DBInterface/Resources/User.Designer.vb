﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.5485
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class User
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.User", GetType(User).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT u.*
        '''FROM tblUser AS u
        '''WHERE u.usergroup_id = &apos;Checker&apos;
        '''	AND u.user_status = &apos;Enabled&apos;
        '''ORDER BY u.user_name;.
        '''</summary>
        Friend Shared ReadOnly Property SelectActiveChecker() As String
            Get
                Return ResourceManager.GetString("SelectActiveChecker", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT integration_key
        '''      ,secret_key
        '''      ,api_hostname
        '''      ,create_dtm
        '''      ,create_by
        '''      ,last_update_dtm
        '''      ,last_update_by
        '''  FROM tblDuoConfig;.
        '''</summary>
        Friend Shared ReadOnly Property SelectKey() As String
            Get
                Return ResourceManager.GetString("SelectKey", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	user_id
        '''	, user_name
        '''	, user_password
        '''	, user_email
        '''	, user_tel
        '''	, user_errlogincount
        '''	, user_errlogindate
        '''	, user_logindate
        '''	, user_logoutdate
        '''	, user_timecount
        '''	, usergroup_id
        '''	, user_status
        '''	, user_permission
        '''	, present_checker_level_id
        '''	, former_checker_level_id
        '''  , password_createdate
        '''  , password_age
        '''  , lock_flag
        '''  , lock_date
        '''FROM tblUser
        '''WHERE user_id = @user_id;.
        '''</summary>
        Friend Shared ReadOnly Property SelectUser() As String
            Get
                Return ResourceManager.GetString("SelectUser", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblUser
        '''SET user_password = @user_password
        '''WHERE user_id = @user_id
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property UpdatePassword() As String
            Get
                Return ResourceManager.GetString("UpdatePassword", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
