Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Establish list of services
        myServiceNames = New List(Of String)()

        ' Test
        myServiceNames.Add("DummyService")

        ' Live
        'myServiceNames.Add("OddsMonitorService")
        myServiceNames.Add("DownloadSpocosyFilesService")
        myServiceNames.Add("LoadSpocosyFilesToDbService1")
        myServiceNames.Add("LoadSpocosyFilesToDbService2")
        myServiceNames.Add("LoadSpocosyFilesToDbService3")
        myServiceNames.Add("LoadSpocosyFilesToDbService4")
        myServiceNames.Add("LoadSpocosyFilesToDbService5")
        myServiceNames.Add("LoadSpocosyDataServiceA")
        myServiceNames.Add("LoadSpocosyDataServiceB")
        myServiceNames.Add("LoadSpocosyDataServiceC")
        myServiceNames.Add("LoadSpocosyDataServiceD")
        myServiceNames.Add("LoadSpocosyDataServiceE")
        myServiceNames.Add("LoadSpocosyDataServiceX")
        myServiceNames.Add("BetFairFeedService")

        ' Loop through each service object to create the list
        For Each strName In myServiceNames

            ' Add to list
            OddsServiceList.Add(New OddsServiceClass(strName))

        Next

        ' Update Status and buttons
        For Each service In OddsServiceList
            UpdateButtons(service)
        Next

    End Sub

    Public Sub UpdateButtons(service As OddsServiceClass)

        For Each thisService In OddsServiceList

            For Each GroupBoxCntrol As Control In Me.Controls
                If TypeOf GroupBoxCntrol Is GroupBox Then
                    For Each cntrl As Control In GroupBoxCntrol.Controls.OfType(Of TextBox)

                        If cntrl.Name.Contains(service.strServiceName) And cntrl.Name.Contains("Status") Then
                            cntrl.Text = service.strStatus
                            If service.strStatus = "Running" Then
                                cntrl.BackColor = Color.PaleGreen
                                cntrl.ForeColor = Color.Black
                            ElseIf service.strStatus = "Stopped" Then
                                cntrl.BackColor = Color.Red
                                cntrl.ForeColor = Color.White
                            End If
                            Exit For
                        End If
                    Next
                End If

            Next
        Next


    End Sub

    Private Sub btnDummyServiceStart_Click(sender As Object, e As EventArgs) Handles btnDummyServiceStart.Click, btnDownloadSpocosyFilesServiceStart.Click,
      btnLoadSpocosyFilesToDbService1Start.Click, btnLoadSpocosyFilesToDbService2Start.Click, btnLoadSpocosyFilesToDbService3Start.Click, btnLoadSpocosyFilesToDbService4Start.Click,
      btnLoadSpocosyFilesToDbService5Start.Click, btnLoadSpocosyDataServiceAStart.Click, btnLoadSpocosyDataServiceBStart.Click, btnLoadSpocosyDataServiceCStart.Click,
      btnLoadSpocosyDataServiceDStart.Click, btnLoadSpocosyDataServiceEStart.Click, btnLoadSpocosyDataServiceXStart.Click, btnBetFairFeedServiceStart.Click

        ' Check status first
        Dim strServiceName As String
        strServiceName = sender.Name.Replace("btn", "").Replace("Start", "")

        For Each service In OddsServiceList

            If service.strServiceName = strServiceName Then

                ' Start the service
                service.StartService(strServiceName)

                ' Sleep for 3secs
                Threading.Thread.Sleep(3000)

                ' Set current status
                service.CheckServiceStatus(service.strServiceName)

                ' Update buttons
                UpdateButtons(service)

            End If
        Next

    End Sub

    Private Sub btnDummyServiceStop_Click(sender As Object, e As EventArgs) Handles btnDummyServiceStop.Click, btnDownloadSpocosyFilesServiceStop.Click,
      btnLoadSpocosyFilesToDbService1Stop.Click, btnLoadSpocosyFilesToDbService2Stop.Click, btnLoadSpocosyFilesToDbService3Stop.Click, btnLoadSpocosyFilesToDbService4Stop.Click,
      btnLoadSpocosyFilesToDbService5Stop.Click, btnLoadSpocosyDataServiceAStop.Click, btnLoadSpocosyDataServiceBStop.Click, btnLoadSpocosyDataServiceCStop.Click,
      btnLoadSpocosyDataServiceDStop.Click, btnLoadSpocosyDataServiceEStop.Click, btnLoadSpocosyDataServiceXStop.Click, btnBetFairFeedServiceStop.Click

        ' Check status first
        Dim strServiceName As String
        strServiceName = sender.Name.Replace("btn", "").Replace("Stop", "")

        For Each service In OddsServiceList
            If service.strServiceName = strServiceName Then

                ' Stop the service
                service.StopService(strServiceName)

                ' Sleep for 3secs
                Threading.Thread.Sleep(3000)

                ' Set current status
                service.CheckServiceStatus(service.strServiceName)

                ' Update status and buttons
                UpdateButtons(service)

            End If
        Next
    End Sub

    Private Sub btnStartAll_Click(sender As Object, e As EventArgs) Handles btnStartAll.Click

        ' Confirm
        Dim result As Integer = MsgBox("Are you sure you want to Start all services?", MsgBoxStyle.YesNo, "Confirmation")
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then

            ' Start each service
            For Each service In OddsServiceList

                ' Start the service
                service.StartService(service.strServiceName)

            Next

            ' Sleep
            Threading.Thread.Sleep(3000)

            ' Start each service
            For Each service In OddsServiceList

                ' Set current status
                service.CheckServiceStatus(service.strServiceName)

                ' Update buttons
                UpdateButtons(service)

            Next

        End If

    End Sub

    Private Sub btnStopAllServices_Click(sender As Object, e As EventArgs) Handles btnStopAllServices.Click

        ' Confirm
        Dim result As Integer = MsgBox("Are you sure you want to Stop all services?", MsgBoxStyle.YesNo, "Confirmation")
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then

            ' Start each service
            For Each service In OddsServiceList

                ' Start the service
                service.StopService(service.strServiceName)

            Next

            ' Sleep
            Threading.Thread.Sleep(3000)

            ' Start each service
            For Each service In OddsServiceList

                ' Set current status
                service.CheckServiceStatus(service.strServiceName)

                ' Update buttons
                UpdateButtons(service)

            Next

        End If
    End Sub

    Private Sub btnRefreshStatus_Click(sender As Object, e As EventArgs) Handles btnRefreshStatus.Click

        ' Refresh status
        For Each service In OddsServiceList

            ' Set current status
            service.CheckServiceStatus(service.strServiceName)

            ' Update buttons
            UpdateButtons(service)

        Next

    End Sub
End Class
