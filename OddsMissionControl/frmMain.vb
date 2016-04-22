Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Establish list of services
        myServiceNames = New List(Of String)()
        myServiceNames.Add("OddsMonitorService")
        myServiceNames.Add("DownloadSpocosyFilesService")
        myServiceNames.Add("BetFairFeedService1")
        myServiceNames.Add("BetFairFeedService7")


        ' Loop through each service object
        For Each service In myServiceNames

            ' Add to list
            OddsServiceList.Add(New OddsServiceClass(service))

        Next

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles tbxLoadSpocosyFilesToDbService1.TextChanged

    End Sub
End Class
