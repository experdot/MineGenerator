Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports MineGenerator.Models
Imports MineGenerator.Commands

Namespace ViewModels

    Public Class MainViewModel
        Inherits ViewModelBase(Of MainViewModel)
        Implements INotifyPropertyChanged


        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

End Namespace