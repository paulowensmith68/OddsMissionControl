Imports System.ServiceProcess

Public Class OddsServiceClass

    Public strName As String
    Public strLogPath As String
    Public strInstallPath As String
    Public strStatus As String

    Public Sub New(ByVal serviceName As String)

        ' Store name
        strName = serviceName

        Select Case serviceName
            Case "OddsMonitorService"
                strLogPath = My.Settings.MasterServiceLogFname
                strInstallPath = My.Settings.MasterServiceConfigFname
            Case "BetFairFeedService"
                strLogPath = My.Settings.BetFairFeedServiceLogFname
                strInstallPath = My.Settings.BetFairFeedServiceConfigFname
        End Select

        ' Set current status
        ConnectToServiceController(".", Me.strName)

    End Sub

    Public Sub ConnectToServiceController(ByVal machineName As String, ByVal serviceName As String, Optional ByVal action As String = "Status")
        Dim myController As ServiceController

        Try

            ' Create an instance of Service Controller
            myController = New ServiceController(serviceName, machineName)

            ' Controller status
            Select Case action

                Case "Start"
                    Try
                        myController.Start()
                        strStatus = myController.Status

                    Catch ex As Exception
                        gobjEvent.WriteToEventLog("OddsServiceClass: Unable to start service: " + ex.Message, EventLogEntryType.Error)
                        Exit Sub
                    End Try

                Case "Stop"
                    Try
                        myController.Stop()
                        strStatus = myController.Status

                    Catch ex As Exception
                        gobjEvent.WriteToEventLog("OddsServiceClass: Unable to stop service: " + ex.Message, EventLogEntryType.Error)
                        Exit Sub
                    End Try

                Case "Status"
                    strStatus = myController.Status
            End Select

        Catch ex As Exception
            gobjEvent.WriteToEventLog("OddsServiceClass: Genaral exception caught service controller: " + ex.Message, EventLogEntryType.Error)
            Exit Sub
        End Try

    End Sub

End Class
