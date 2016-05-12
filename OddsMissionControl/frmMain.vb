Imports MySql.Data.MySqlClient

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Establish list of services
        myServiceNames = New List(Of String)()

        ' Test
        'myServiceNames.Add("DummyService")

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
        myServiceNames.Add("BetFairFeedService1")
        myServiceNames.Add("BetFairFeedService2")
        myServiceNames.Add("HousekeepStagingService")

        ' Loop through each service object to create the list
        For Each strName In myServiceNames

            ' Add to list
            OddsServiceList.Add(New OddsServiceClass(strName))

        Next

        ' Update Status and buttons
        For Each service In OddsServiceList
            UpdateButtons(service)
        Next

        ' Update Remote File Status
        CheckFileStatus()

        ' Database counts
        DatabaseCounts()


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

    Private Sub btnDummyServiceStart_Click(sender As Object, e As EventArgs) Handles btnDownloadSpocosyFilesServiceStart.Click,
      btnLoadSpocosyFilesToDbService1Start.Click, btnLoadSpocosyFilesToDbService2Start.Click, btnLoadSpocosyFilesToDbService3Start.Click, btnLoadSpocosyFilesToDbService4Start.Click,
      btnLoadSpocosyFilesToDbService5Start.Click, btnLoadSpocosyDataServiceAStart.Click, btnLoadSpocosyDataServiceBStart.Click, btnLoadSpocosyDataServiceCStart.Click,
      btnLoadSpocosyDataServiceDStart.Click, btnLoadSpocosyDataServiceEStart.Click, btnLoadSpocosyDataServiceXStart.Click, btnBetFairFeedService1Start.Click

        ' Disable the timer
        If Timer1.Enabled Then
            Me.btnRefreshAutoOff_Click(sender, e)
        End If

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

    Private Sub btnDummyServiceStop_Click(sender As Object, e As EventArgs) Handles btnDownloadSpocosyFilesServiceStop.Click,
      btnLoadSpocosyFilesToDbService1Stop.Click, btnLoadSpocosyFilesToDbService2Stop.Click, btnLoadSpocosyFilesToDbService3Stop.Click, btnLoadSpocosyFilesToDbService4Stop.Click,
      btnLoadSpocosyFilesToDbService5Stop.Click, btnLoadSpocosyDataServiceAStop.Click, btnLoadSpocosyDataServiceBStop.Click, btnLoadSpocosyDataServiceCStop.Click,
      btnLoadSpocosyDataServiceDStop.Click, btnLoadSpocosyDataServiceEStop.Click, btnLoadSpocosyDataServiceXStop.Click, btnBetFairFeedService1Stop.Click

        ' Disable the timer
        If Timer1.Enabled Then
            Me.btnRefreshAutoOff_Click(sender, e)
        End If

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

        ' Disable the timer
        If Timer1.Enabled Then
            Me.btnRefreshAutoOff_Click(sender, e)
        End If

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

        ' Disable the timer
        If Timer1.Enabled Then
            Me.btnRefreshAutoOff_Click(sender, e)
        End If

        ' Confirm
        Dim result As Integer = MsgBox("Are you sure you want to Stop all services?", MsgBoxStyle.YesNo, "Confirmation")
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then

            ' Start each service
            For Each service In OddsServiceList

                ' Stop the service
                service.StopService(service.strServiceName)

                ' Wait to flush downloaded files
                If service.strServiceName.Contains("DownloadSpocosyFiles") Then
                    rtbLog.AppendText("Sleeping for 15secs for downloads...")
                    rtbLog.ScrollToCaret()
                    Application.DoEvents()
                    Threading.Thread.Sleep(15000)
                End If

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

        ' Update Remote File Status
        CheckFileStatus()

        ' Database counts
        DatabaseCounts()

    End Sub

    Private Sub btnMonitorServiceNameChangeSettings_Click(sender As Object, e As EventArgs) Handles btnDownloadSpocosyFilesServiceSettings.Click,
      btnLoadSpocosyFilesToDbService1Settings.Click, btnLoadSpocosyFilesToDbService2Settings.Click, btnLoadSpocosyFilesToDbService3Settings.Click, btnLoadSpocosyFilesToDbService4Settings.Click,
      btnLoadSpocosyFilesToDbService5Settings.Click, btnLoadSpocosyDataServiceASettings.Click, btnLoadSpocosyDataServiceBSettings.Click, btnLoadSpocosyDataServiceCSettings.Click,
      btnLoadSpocosyDataServiceDSettings.Click, btnLoadSpocosyDataServiceESettings.Click, btnLoadSpocosyDataServiceXSettings.Click, btnBetFairFeedService1Settings.Click

        Dim strServiceName As String
        strServiceName = sender.Name.Replace("btn", "").Replace("Settings", "")

        For Each service In OddsServiceList

            If service.strServiceName = strServiceName Then

                service.OpenSettings()

            End If
        Next

    End Sub

    Public Sub CheckFileStatus()

        Dim ftp As FTP
        Dim RFN As String = My.Settings.RemoteFtpServer + My.Settings.RemoteFtpPath
        Dim LFN As String = My.Settings.LocalDownloadPath


        ' Check remote files by connecting to server
        Try

            ' Connect
            ftp = New FTP(My.Settings.RemoteServerUser, My.Settings.RemoteServerPassword)

            tbxFtpServerConnection.BackColor = Color.PaleGreen
            tbxFtpServerConnection.ForeColor = Color.Black
            tbxFtpServerConnection.Text = "Connection ok"

        Catch ex As Exception

            tbxFtpServerConnection.BackColor = Color.Red
            tbxFtpServerConnection.ForeColor = Color.White
            tbxFtpServerConnection.Text = "Connection Failed"
            Exit Sub
        End Try

        ' Clear
        rtbRemoteFileList.Clear()
        Dim fileCount As Integer

        Dim remoteFileList As List(Of String) = ftp.GetDirectory(RFN)
        For Each file In remoteFileList
            If file.Contains(".xml") Then
                fileCount = fileCount + 1
                rtbRemoteFileList.AppendText(file + vbCrLf)
                rtbRemoteFileList.ScrollToCaret()
            End If
        Next

        ' Populate count
        tbxRemoteFileCount.Text = fileCount.ToString("N0")

        ' Get local file count
        Dim counter = My.Computer.FileSystem.GetFiles(LFN)
        tbxLocalFileCount.Text = counter.Count.ToString("N0")

    End Sub

    Public Sub DatabaseCounts()

        ' Populate counts
        tbxSavedXmlCount.Text = CountSavedXmlRows().ToString("N0")
        tbxStreammedXml.Text = CountSavedStreammedXmlRows().ToString("N0")
        tbxStagingTableRows.Text = CountBookmakerXmlNodesRows().ToString("N0")


    End Sub

    Public Function CountSavedXmlRows() As Integer

        Dim countRows As Integer = 0
        Dim myConnection As New MySqlConnection(My.Settings.ConnectionString)
        Dim myCommand As New MySqlCommand("SELECT count(*) FROM saved_xml")
        myCommand.CommandType = CommandType.Text
        myCommand.Connection = myConnection

        Try

            myConnection.Open()
            countRows = Convert.ToInt64(myCommand.ExecuteScalar())

        Catch ex As Exception

        Finally

            myConnection.Close()

        End Try

        Return countRows

    End Function

    Public Function CountSavedStreammedXmlRows() As Integer

        Dim countRows As Integer = 0
        Dim myConnection As New MySqlConnection(My.Settings.ConnectionString)
        Dim myCommand As New MySqlCommand("SELECT count(*) FROM saved_streammed_xml")
        myCommand.CommandType = CommandType.Text
        myCommand.Connection = myConnection

        Try

            myConnection.Open()
            countRows = Convert.ToInt64(myCommand.ExecuteScalar())

        Catch ex As Exception

        Finally

            myConnection.Close()

        End Try

        Return countRows

    End Function

    Public Function CountBookmakerXmlNodesRows() As Integer

        Dim countRows As Integer = 0
        Dim myConnection As New MySqlConnection(My.Settings.ConnectionString)
        Dim myCommand As New MySqlCommand("SELECT count(*) FROM bookmaker_xml_nodes;")
        myCommand.CommandType = CommandType.Text
        myCommand.Connection = myConnection

        Try

            myConnection.Open()
            countRows = Convert.ToInt64(myCommand.ExecuteScalar())

        Catch ex As Exception

        Finally

            myConnection.Close()

        End Try

        Return countRows

    End Function

    Private Sub btnRefreshAutoOn_Click(sender As Object, e As EventArgs) Handles btnRefreshAutoOn.Click
        Timer1.Enabled = True
        btnRefreshAutoOff.Enabled = True
        btnRefreshAutoOn.Enabled = False
    End Sub

    Private Sub btnRefreshAutoOff_Click(sender As Object, e As EventArgs) Handles btnRefreshAutoOff.Click
        Timer1.Enabled = False
        btnRefreshAutoOn.Enabled = True
        btnRefreshAutoOff.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Refresh status
        For Each service In OddsServiceList

            ' Set current status
            service.CheckServiceStatus(service.strServiceName)

            ' Update buttons
            UpdateButtons(service)

        Next

        ' Update Remote File Status
        CheckFileStatus()

        ' Database counts
        DatabaseCounts()

    End Sub
End Class
