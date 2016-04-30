Imports System.ServiceProcess

Public Class OddsServiceClass

    Public strServiceName As String
    Public strLogPath As String
    Public strInstallPath As String
    Public strStatus As String


    Public Sub New(ByVal serviceName As String)

        ' Store name
        strServiceName = serviceName

        Select Case serviceName

            Case "DummyService"
                strLogPath = My.Settings.DummyServiceLogFname
                strInstallPath = My.Settings.DummyServiceConfigFname

                'Case "OddsMonitorService"
                '    strLogPath = My.Settings.MasterServiceLogFname
                '    strInstallPath = My.Settings.MasterServiceConfigFname

                'Case "BetFairFeedService"
                '    strLogPath = My.Settings.BetFairFeedServiceLogFname
                '    strInstallPath = My.Settings.BetFairFeedServiceConfigFname

        End Select

        ' Set current status
        CheckServiceStatus(Me.strServiceName)

    End Sub

    Public Sub CheckServiceStatus(ByVal serviceName As String)

        Try

            ' Create an instance of Service Controller
            Dim service As ServiceController = New ServiceController(serviceName)

            If service.Status = ServiceControllerStatus.Running Then
                strStatus = "Running"
            ElseIf service.Status = ServiceControllerStatus.Stopped Then
                strStatus = "Stopped"
            ElseIf service.Status = ServiceControllerStatus.StartPending Then
                strStatus = "Start Pending"
            ElseIf service.Status = ServiceControllerStatus.StopPending Then
                strStatus = "Stop Pending"
            ElseIf service.Status = ServiceControllerStatus.Paused Then
                strStatus = "Paused"
            ElseIf service.Status = ServiceControllerStatus.PausePending Then
                strStatus = "Pause Pending"
            ElseIf service.Status = ServiceControllerStatus.ContinuePending Then
                strStatus = "Continue Pending"
            End If

        Catch ex As Exception

            gobjEvent.WriteToEventLog("OddsServiceClass: Genaral exception caught service controller: " + ex.Message, EventLogEntryType.Error)

        End Try

    End Sub

    Public Sub StartService(serviceName As String)

        Try
            Dim service As ServiceController = New ServiceController(serviceName)
            If ((service.Status.Equals(ServiceControllerStatus.Stopped)) Or
                (service.Status.Equals(ServiceControllerStatus.StopPending))) Then

                ' Write to log
                frmMain.rtbLog.AppendText("Starting service " + serviceName + "..." + vbCrLf)
                frmMain.rtbLog.ScrollToCaret()
                Application.DoEvents()

                service.Start()

            Else

                ' Write to log
                frmMain.rtbLog.AppendText("Service " + serviceName + " is already started. No action taken." + vbCrLf)

            End If

        Catch ex As Exception

            gobjEvent.WriteToEventLog("OddsServiceClass: Genaral exception caught service controller: " + ex.Message, EventLogEntryType.Error)

        End Try

    End Sub

    Public Sub StopService(serviceName As String)

        Try
            Dim service As ServiceController = New ServiceController(serviceName)
            If ((service.Status.Equals(ServiceControllerStatus.Stopped)) Or
                (service.Status.Equals(ServiceControllerStatus.StopPending))) Then

                ' Write to log
                frmMain.rtbLog.AppendText("Service " + serviceName + " is already stopped. No action taken." + vbCrLf)
            Else

                ' Write to log
                frmMain.rtbLog.AppendText("Stopping service " + serviceName + "..." + vbCrLf)
                frmMain.rtbLog.ScrollToCaret()
                Application.DoEvents()

                service.Stop()

            End If

        Catch ex As Exception
        End Try

    End Sub
End Class
