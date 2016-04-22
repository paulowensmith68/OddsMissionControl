Public Class SchedulerClass

    Public Sub StopAllServiceControlled(ByVal serviceList As List(Of OddsServiceClass))

        ' Iterate through each service
        For Each service In serviceList

            ' Check status
            If service.strStatus = "Running" Then

                ' Check log for sleepy time


            Else

                ' Stop
                service.ConnectToServiceController(".", service.strName)

            End If

        Next

    End Sub

    Public Function ServiceSleeping(ByVal logFilename As String) As Boolean
        Dim fso
        Dim f
        Dim j As Long 'Loop counter
        Dim s As String 'Dummy String
        Dim NumberOfRecords As Long
        Dim blnReturn As Boolean = True

        Const ForReading = 1
        Const nLines = 10

        fso = CreateObject("Scripting.FileSystemObject")
        f = fso.OpenTextFile(logFilename, ForReading)
        NumberOfRecords = f.Line - 1
        For j = 1 To NumberOfRecords - nLines


            s = f.SkipLine
        Next

        'You could put the rest into an Array
        'v = Split((f.readall), vbLf)

        For j = 1 To nLines
            Debug.Print(f.ReadLine)
        Next

        f.Close()
        f = Nothing
        fso = Nothing

        Return blnReturn

    End Function

End Class
