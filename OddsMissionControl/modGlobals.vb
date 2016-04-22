Option Strict Off
Option Explicit On
Module modGlobals

    '-------------------------------------------------
    '-   Logging objects                             -
    '-------------------------------------------------
    Public gobjEvent As EventLogger = New EventLogger

    '-------------------------------------------------
    '-   Constants                                   -
    '-------------------------------------------------

    '-------------------------------------------------
    '-   Global                                   -
    '-------------------------------------------------
    ' Create a list of service objects
    Public OddsServiceList As New List(Of OddsServiceClass)()

    ' Create list of services
    Public myServiceNames As List(Of String)

End Module


