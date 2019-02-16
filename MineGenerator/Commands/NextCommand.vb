Namespace Commands

    Public Class NextCommand
        Implements ICommand

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Property KeyboardSimulationAction As Action

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            KeyboardSimulationAction?.Invoke()
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function
    End Class

End Namespace
