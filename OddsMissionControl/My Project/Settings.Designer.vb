﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("c:\#myPrograms\OddsMissionControl\logs\")>  _
        Public Property ProcessLogPath() As String
            Get
                Return CType(Me("ProcessLogPath"),String)
            End Get
            Set
                Me("ProcessLogPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("ftp://waws-prod-db3-025.ftp.azurewebsites.windows.net")>  _
        Public Property RemoteFtpServer() As String
            Get
                Return CType(Me("RemoteFtpServer"),String)
            End Get
            Set
                Me("RemoteFtpServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WebAppBookmakerFeed20160413071258\paulowensmith19682")>  _
        Public Property RemoteServerUser() As String
            Get
                Return CType(Me("RemoteServerUser"),String)
            End Get
            Set
                Me("RemoteServerUser") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("PS?pos68")>  _
        Public Property RemoteServerPassword() As String
            Get
                Return CType(Me("RemoteServerPassword"),String)
            End Get
            Set
                Me("RemoteServerPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property MaxFilesToDownload() As Integer
            Get
                Return CType(Me("MaxFilesToDownload"),Integer)
            End Get
            Set
                Me("MaxFilesToDownload") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("/site/wwwroot/files/")>  _
        Public Property RemoteFtpPath() As String
            Get
                Return CType(Me("RemoteFtpPath"),String)
            End Get
            Set
                Me("RemoteFtpPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myFiles\Downloaded\")>  _
        Public Property LocalDownloadPath() As String
            Get
                Return CType(Me("LocalDownloadPath"),String)
            End Get
            Set
                Me("LocalDownloadPath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\DummyService\program\DummyService.exe.config")>  _
        Public Property DummyServiceConfigFname() As String
            Get
                Return CType(Me("DummyServiceConfigFname"),String)
            End Get
            Set
                Me("DummyServiceConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Program Files (x86)\Notepad++\notepad++.exe")>  _
        Public Property ConfigEditor() As String
            Get
                Return CType(Me("ConfigEditor"),String)
            End Get
            Set
                Me("ConfigEditor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\DownloadSpocosyFilesService\program\DownloadSpocosyFilesService.ex"& _ 
            "e.config")>  _
        Public Property DownloadSpocosyFilesServiceConfigFname() As String
            Get
                Return CType(Me("DownloadSpocosyFilesServiceConfigFname"),String)
            End Get
            Set
                Me("DownloadSpocosyFilesServiceConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyFilesToDbService\program1\LoadSpocosyFilesToDbService.e"& _ 
            "xe.config")>  _
        Public Property LoadSpocosyFilesToDbService1ConfigFname() As String
            Get
                Return CType(Me("LoadSpocosyFilesToDbService1ConfigFname"),String)
            End Get
            Set
                Me("LoadSpocosyFilesToDbService1ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyFilesToDbService\program2\LoadSpocosyFilesToDbService.e"& _ 
            "xe.config")>  _
        Public Property LoadSpocosyFilesToDbService2ConfigFname() As String
            Get
                Return CType(Me("LoadSpocosyFilesToDbService2ConfigFname"),String)
            End Get
            Set
                Me("LoadSpocosyFilesToDbService2ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyFilesToDbService\program3\LoadSpocosyFilesToDbService.e"& _ 
            "xe.config")>  _
        Public Property LoadSpocosyFilesToDbService3ConfigFname() As String
            Get
                Return CType(Me("LoadSpocosyFilesToDbService3ConfigFname"),String)
            End Get
            Set
                Me("LoadSpocosyFilesToDbService3ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyFilesToDbService\program4\LoadSpocosyFilesToDbService.e"& _ 
            "xe.config")>  _
        Public Property LoadSpocosyFilesToDbService4ConfigFname() As String
            Get
                Return CType(Me("LoadSpocosyFilesToDbService4ConfigFname"),String)
            End Get
            Set
                Me("LoadSpocosyFilesToDbService4ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyFilesToDbService\program5\LoadSpocosyFilesToDbService.e"& _ 
            "xe.config")>  _
        Public Property LoadSpocosyFilesToDbService5ConfigFname() As String
            Get
                Return CType(Me("LoadSpocosyFilesToDbService5ConfigFname"),String)
            End Get
            Set
                Me("LoadSpocosyFilesToDbService5ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programA\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceAConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceAConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceAConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programB\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceBConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceBConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceBConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programC\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceCConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceCConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceCConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programD\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceDConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceDConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceDConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programE\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceEConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceEConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceEConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\LoadSpocosyDataService\programX\LoadSpocosyDataService.exe.config")>  _
        Public Property LoadSpocosyDataServiceXConfgFname() As String
            Get
                Return CType(Me("LoadSpocosyDataServiceXConfgFname"),String)
            End Get
            Set
                Me("LoadSpocosyDataServiceXConfgFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\BetFairFeedService\program1\BetFairFeedService.exe.config")>  _
        Public Property BetFairFeedService1ConfigFname() As String
            Get
                Return CType(Me("BetFairFeedService1ConfigFname"),String)
            End Get
            Set
                Me("BetFairFeedService1ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\BetFairFeedService\program2\BetFairFeedService.exe.config")>  _
        Public Property BetFairFeedService2ConfigFname() As String
            Get
                Return CType(Me("BetFairFeedService2ConfigFname"),String)
            End Get
            Set
                Me("BetFairFeedService2ConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\#myPrograms\HousekeepStagingService\program\HousekeepStagingService.exe.config"& _ 
            "")>  _
        Public Property HousekeepStagingServiceConfigFname() As String
            Get
                Return CType(Me("HousekeepStagingServiceConfigFname"),String)
            End Get
            Set
                Me("HousekeepStagingServiceConfigFname") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Database=OddsMatching;Data Source=eu-cdbr-azure-north-e.cloudapp.net;User Id=b083"& _ 
            "cb50265fec;Password=263fb5f7;persistsecurityinfo=True")>  _
        Public ReadOnly Property ConnectionString() As String
            Get
                Return CType(Me("ConnectionString"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.OddsMissionControl.My.MySettings
            Get
                Return Global.OddsMissionControl.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
