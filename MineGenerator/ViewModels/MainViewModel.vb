Imports MineGenerator.Models
Imports MineGenerator.Commands

Namespace ViewModels

    Public Class MainViewModel
        Inherits ViewModelBase(Of MainViewModel)

        Public Property PreviewImage As BitmapSource
            Get
                Return BlockManager.RawBitmapSource
            End Get
            Set(value As BitmapSource)
                If Not value.Equals(BlockManager.RawBitmapSource) Then
                    BlockManager.RawBitmapSource = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property ImportCommand As New ImportCommand
        Public ReadOnly Property NextCommand As New NextCommand

        Public ReadOnly Property BlockManager As New BlockManager

        Public Sub New()
            AddHandler ImportCommand.BitmapSourceChanged, AddressOf OnBitmapSourceChanged
            NextCommand.KeyboardSimulationAction = AddressOf BlockManager.Build
        End Sub

        Public Sub OnBitmapSourceChanged(sender As Object, bitmapSource As BitmapSource)
            PreviewImage = bitmapSource
        End Sub
    End Class

End Namespace