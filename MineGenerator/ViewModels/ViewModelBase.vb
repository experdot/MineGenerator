Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports MineGenerator.Helpers

Namespace ViewModels

    Public Class ViewModelBase(Of T As {New, ViewModelBase(Of T)})
        Inherits Singleton(Of T)
        Implements INotifyPropertyChanged

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class

End Namespace