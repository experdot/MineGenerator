Imports Microsoft.Win32

Namespace Commands

    Public Class ImportCommand
        Implements ICommand
        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
        Public Event BitmapSourceChanged As EventHandler(Of BitmapSource)

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            ImportFromFile()
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Private Sub ImportFromFile()
            Dim dialog As New OpenFileDialog()
            If dialog.ShowDialog() Then
                Dim fileName = dialog.FileName
                Dim image = New BitmapImage(New Uri(fileName))
                RaiseEvent BitmapSourceChanged(Me, image)
            End If
        End Sub

        Private Sub ImportFromClipboard()
            If (Clipboard.ContainsImage()) Then
                RaiseEvent BitmapSourceChanged(Me, Clipboard.GetImage())
            End If
        End Sub
    End Class

End Namespace
