Imports System.Threading

Class Application

    Dim singleInstance As Mutex

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        Environment.SetEnvironmentVariable("PATH",
                                           String.Concat(Environment.GetEnvironmentVariable("PATH"),
                                                         ";",
                                                         AppDomain.CurrentDomain.RelativeSearchPath),
                                           EnvironmentVariableTarget.Process)
        AddHandler AppDomain.CurrentDomain.UnhandledException,
            Sub(sender1, e1)
                Dim pa = IO.Path.Combine(IO.Path.GetDirectoryName(
                                         Process.GetCurrentProcess.MainModule.FileName), "except.txt")
                MsgBox("The app has encountered an internal error and is unable to continue normally.
Please send the generated ""except.txt"" to https://github.com/experdot/MineGenerator/issues .",
                       vbExclamation, "Oops")
                IO.File.WriteAllText(pa, e1.ExceptionObject.ToString)
            End Sub

        Dim isNew = False

        singleInstance = New Mutex(True, "ExperdotNukepayload2" + Me.GetType.Namespace, isNew)
        If Not isNew Then
            MsgBox("You can't run more than one instance of this app.", vbExclamation)
            Shutdown()
        End If
    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]
        singleInstance.Dispose()
    End Sub
End Class
